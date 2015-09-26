<?php

namespace SoftUni\Core;

use \SoftUni\ViewModels\User;

class BuildingsRepository
{
    /**
     * @var Database
     */
    private $db;

    /**
     * @var \SoftUni\ViewModels\User
     */
    private $user;

    public function __construct(Database $db, User $user){
        $this->db = $db;
        $this->user = $user;
    }

    public function getUser(){
        return $this->user;
    }

    public function getBuildings(){
        $result = $this->db->prepare("
            SELECT
              id,
              building_id,
              (level_id + 1) as level,
              (SELECT gold FROM building_levels WHERE level = user_buildings.level_id + 1 AND building_id = user_buildings.building_id) as gold,
              (SELECT food FROM building_levels WHERE level = user_buildings.level_id + 1 AND building_id = user_buildings.building_id) as food,
              (SELECT name FROM buildings WHERE id = user_buildings.building_id) as name
            FROM user_buildings
            WHERE user_id = ?
        ");

        $result->execute([$this->user->getId()]);

        return $result->fetchAll();
    }

    public function evolve($buildingId){
        $result = $this->db->prepare("
            SELECT
              id,
              building_id,
              (level_id + 1) as level,
              (SELECT gold FROM building_levels WHERE level = user_buildings.level_id + 1 AND building_id = user_buildings.building_id) as gold,
              (SELECT food FROM building_levels WHERE level = user_buildings.level_id + 1 AND building_id = user_buildings.building_id) as food,
              (SELECT name FROM buildings WHERE id = user_buildings.building_id) as name
            FROM user_buildings
            WHERE user_id = ? AND building_id = ?
        ");

        $result->execute([$this->user->getId(), $buildingId]);
        $buildingData = $result->fetch();

        if($this->user->getGold() < $buildingData['gold'] || $this->user->getFood() < $buildingData['food']){
            throw new \Exception('Not enough resources');
        }

        if ($buildingData['gold'] == null){
            throw new \Exception('Building max level reached');
        }

        $resourceUpdate = $this->db->prepare("UPDATE users SET gold = ?, food = ? WHERE id = ?");

        $resourceUpdate->execute([
            $this->user->getGold() - $buildingData['gold'],
            $this->user->getFood() - $buildingData['food'],
            $this->user->getId()
        ]);

        $this->user->setGold($this->user->getGold() - $buildingData['gold']);
        $this->user->setFood($this->user->getFood() - $buildingData['food']);

        if($resourceUpdate->rowCount() > 0){
            $levelUpdate = $this->db->prepare("UPDATE user_buildings SET level_id = ? WHERE user_id = ? AND building_id = ?");
            $levelUpdate->execute([
                $buildingData['level'],
                $this->user->getId(),
                $buildingId
            ]);

            if ($levelUpdate->rowCount() > 0){
                return true;
            }

            throw new \Exception("Something went wrong");
        }

        throw new \Exception("Something went wrong");
    }
}