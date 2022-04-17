using System;
using System.Collections.Generic;
using System.Linq;

namespace Mybarber.Services
{
    public static class GerarHorarioServices
    {
        public static IEnumerable<float> FloatRange(float min, float max, float step)
        {
            for (float value = min; value <= max; value += step)
            {
                yield return value;
            }
        }


        public static List<DateTime> RetornaHorario()
        {

            var agora = DateTime.Now;
            var agendadosFloat = new List<float>  {8.00f, 17.50f};
            


            IEnumerable<float> Ienumerable = FloatRange(8.00f, 18.00f, 0.5f);

            var Lista = Ienumerable.ToList();
            var horasLista = new List<DateTime>();
;
            foreach(float item in Lista.ToList())
            {
                

                if (agendadosFloat.Contains(item))
                {

                     Lista.RemoveAt(Lista.FindIndex(x => x == item));


                }
                var horas = Convert.ToDateTime(item);
                horasLista.Add(horas);
                


            }
            
            
            return  horasLista;
        }
        
       



    }
}
