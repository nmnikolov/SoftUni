namespace School
{
    using System;
    using System.Linq;
    using System.Text;

    using System.Collections.Generic;

    public class Teacher : Person, IDetailable
    {

        public Teacher(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines { get; set; }

        public void AddDisciplines(params Discipline[] list)
        {
            foreach (Discipline discipline in list)
            {
                this.Disciplines.Add(discipline);
            }
        }

        public override string ToString()
        {
            var disciplinesName = this.Disciplines
                .Select(r => r.Name.ToString())
                .ToArray();

            StringBuilder result = new StringBuilder(base.ToString());
            if (disciplinesName.Length > 0)
            {
                result.AppendFormat("Disciplines: {0}\n", String.Join(", ", disciplinesName));
            }

            return result.ToString();
        }
    }
}