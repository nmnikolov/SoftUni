---------------------------------------------
---- Problem 9
---------------------------------------------
--SELECT 
--	c.CountryName,
--	cn.ContinentName,
--	COUNT(r.Id) AS RiversCount,
--	ISNULL(SUM(r.Length), 0) AS TotalLength	
--FROM Countries AS c
--INNER JOIN Continents AS cn
--ON c.ContinentCode = cn.ContinentCode
--LEFT JOIN CountriesRivers AS cr
--ON	c.CountryCode = cr.CountryCode
--LEFT JOIN Rivers AS r
--On cr.RiverId = r.Id
--GROUP BY c.CountryName, cn.ContinentName
--ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName ASC

-------------------------------------------
-- Problem 10
-------------------------------------------
--SELECT
--	c.CurrencyCode AS CurrencyCode,
--	c.Description AS Currency,
--	COUNT(cr.CurrencyCode) AS NumberOfCountries
--FROM Currencies AS c
--LEFT JOIN Countries AS cr
--ON c.CurrencyCode = cr.CurrencyCode
--GROUP BY c.CurrencyCode, c.Description
--ORDER BY NumberOfCountries DESC, c.Description

-------------------------------------------
-- Problem 11
-------------------------------------------
--SELECT 
--	cn.ContinentName,
--	SUM(c.AreaInSqKm) AS CountriesArea,
--	sum(cast(c.Population as bigint)) AS CountriesPopulation
--FROM Continents AS cn
--JOIN Countries AS c
--ON cn.ContinentCode = c.ContinentCode
--GROUP BY cn.ContinentName
--ORDER BY CountriesPopulation DESC

-------------------------------------------
-- Problem 12
-------------------------------------------
--SELECT 
--	c.CountryName,
--	MAX(p.Elevation) AS HighestPeakElevation,
--	MAX(r.Length) as LongestRiverLength
--FROM Countries AS c
--LEFT JOIN CountriesRivers AS cr
--ON c.CountryCode = cr.CountryCode
--LEFT JOIN Rivers AS r
--ON cr.RiverId = r.Id
--LEFT JOIN MountainsCountries AS mc
--ON mc.CountryCode = c.CountryCode
--LEFT JOIN Mountains AS m
--ON mc.MountainId = m.Id
--LEFT JOIN Peaks AS p
--ON p.MountainId = m.Id
--GROUP BY c.CountryName
--ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName ASC

-------------------------------------------
-- Problem 13
-------------------------------------------
--SELECT 
--	p.PeakName,
--	r.RiverName,
--	LOWER(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1) + r.RiverName) AS Mix
--FROM Peaks AS p
--JOIN Rivers as r
--ON RIGHT(p.PeakName, 1) LIKE LEFT(r.RiverName, 1)
--ORDER BY Mix ASC

-------------------------------------------
-- Problem 14
-------------------------------------------
SELECT
	c.CountryName AS Country,
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
LEFT JOIN Peaks p
ON p.MountainId = m.Id
GROUP BY c.CountryName, p.PeakName, m.MountainRange
--ORDER BY Country ASC, [Highest Peak Elevation] DESC