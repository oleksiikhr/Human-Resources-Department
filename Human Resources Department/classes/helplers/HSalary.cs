namespace Human_Resources_Department.classes.helplers
{
    class HSalary
    {
        double salary;

        const double K_NDFL = 0.18;
        const double K_VZ   = 0.015;
        const double K_ESV  = 0.22;

        public HSalary(double salary)
        {
            this.salary = salary;
        }

        public double GetNDFL()
        {
            return salary * K_NDFL;
        }

        public double GetVZ()
        {
            return salary * K_VZ;
        }

        public double GetESV()
        {
            return salary * K_ESV;
        }

        public double GetClearSalary()
        {
            return salary - GetNDFL() - GetVZ();
        }
    }
}
