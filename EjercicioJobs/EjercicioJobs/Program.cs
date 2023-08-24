using System;

namespace EjercicioJobs
{
    //Bono adicional
    public class Compañia
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void AñadirEmpleado(Empleado emp)
        {
            empleados.Add(emp);
        }

        public void OtorgarBono()
        {
            foreach (var emp in empleados)
            {
                if (!(emp is Voluntario))
                {
                    emp.SalarioBrutoMensual += emp.SalarioBrutoAnual * 0.10 / 12;
                    emp.CalcularSalario(); // Actualiza el salario neto después del bono
                }
            }
        }
    }
}