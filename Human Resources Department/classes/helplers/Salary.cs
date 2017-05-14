namespace Human_Resources_Department.classes.helplers
{
    class Salary
    {
        const double K_NDFL = 0.18;
        const double K_VZ   = 0.015;
        const double K_ESV  = 0.22;

        public static double GetNDFL(double salary)
        {
            return salary * K_NDFL;
        }

        public static double GetVZ(double salary)
        {
            return salary * K_VZ;
        }

        public static double GetESV(double salary)
        {
            return salary * K_ESV;
        }

        public static double GetClearSalary(double salary)
        {
            return salary - GetNDFL(salary) - GetVZ(salary);
        }
    }
}
