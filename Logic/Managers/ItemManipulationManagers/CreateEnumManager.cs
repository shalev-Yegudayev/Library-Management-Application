using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    internal class CreateEnumManager
    {
        private static double CreateCategoryNumber(bool[] array)
        {
            double num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]) num += Math.Pow(2, i);
            }
            return num;
        }

        internal static T CreateCategoryEnum<T>(bool[] array) where T : Enum
        {
            int num = (int)CreateCategoryNumber(array);
            return (T)(object)num;
        }

    }
}
