using System;


namespace EjercicioJobs
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public double SalarioBrutoMensual { get; set; }
        public double SalarioNetoMensual { get; set; }

        public double SalarioBrutoAnual => SalarioBrutoMensual * 12;
        public double SalarioNetoAnual => SalarioNetoMensual * 12;

        public abstract double ObtenerTasaImpuesto();

        public virtual void CalcularSalario()
        {
            SalarioNetoMensual = SalarioBrutoMensual * (1 - ObtenerTasaImpuesto());
        }
    }

    public class Jefe : Empleado
    {
        public override double ObtenerTasaImpuesto()
        {
            return 0.32;
        }

        public override void CalcularSalario()
        {
            if (SalarioBrutoMensual <= 8000)
                throw new Exception("Salario inválido para Jefe.");
            base.CalcularSalario();
        }
    }

    public class Gerente : Empleado
    {
        public override double ObtenerTasaImpuesto()
        {
            return 0.26;
        }

        public override void CalcularSalario()
        {
            if (SalarioBrutoMensual <= 3000 || SalarioBrutoMensual >= 5000)
                throw new Exception("Salario inválido para Gerente.");
            base.CalcularSalario();
        }
    }

    public class Senior : Empleado
    {
        public override double ObtenerTasaImpuesto()
        {
            return 0.24;
        }

        public override void CalcularSalario()
        {
            if (SalarioBrutoMensual <= 2700 || SalarioBrutoMensual >= 4000)
                throw new Exception("Salario inválido para Senior.");
            base.CalcularSalario();
        }
    }

    public class Intermedio : Empleado
    {
        public override double ObtenerTasaImpuesto()
        {
            return 0.15;
        }

        public override void CalcularSalario()
        {
            if (SalarioBrutoMensual <= 1800 || SalarioBrutoMensual >= 2500)
                throw new Exception("Salario inválido para Intermedio.");
            base.CalcularSalario();
        }
    }

    public class Junior : Empleado
    {
        public override double ObtenerTasaImpuesto()
        {
            return 0.02;
        }

        public override void CalcularSalario()
        {
            if (SalarioBrutoMensual <= 900 || SalarioBrutoMensual >= 1600)
                throw new Exception("Salario inválido para Junior.");
            base.CalcularSalario();
        }
    }

    public class Voluntario : Empleado
    {
        public bool EsAyudaGubernamental { get; set; }

        public override double ObtenerTasaImpuesto()
        {
            return 0;
        }

        public override void CalcularSalario()
        {
            if (EsAyudaGubernamental)
                SalarioBrutoMensual = 300;
            else
                SalarioBrutoMensual = 0;

            base.CalcularSalario();
        }
    }

}
