using System.ComponentModel.DataAnnotations;

namespace shoponline.Pages
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public int? SalaryExpectation { get; set; }
        //public DateTime? Availability { get; set; }
        public DateTime Availability { get; set; } = DateTime.Now;
        public bool buttonClicked1 = false;

        public override string ToString()
        {
            return "{Id:" + Id + ", Fullname:" + Fullname + ", Description:" + Description +
                ", SalaryExpectation:" + SalaryExpectation + ", Availability:" + Availability + "}";
        }
    }
}
