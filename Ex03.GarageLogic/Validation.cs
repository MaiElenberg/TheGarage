using System;

namespace GarageLogicValidation
{
    public class Validation
    {

        public static bool ValidateRangeInt(string i_Range, int i_Min, int i_Max)
        {
            bool success = true;

            if (!(int.TryParse(i_Range, out int type)))
            {
                throw new FormatException();
            }
            if (!(type >= i_Min && type <= i_Max))
            {
                throw new GarageLogicException.ValueOutOfRangeException(i_Min, i_Max);
            }

           return success;
        }

        public static bool ValidateRangeFloat(string i_Range, float i_Min, float i_Max)
        {
            bool success = true;

            if (!(float.TryParse(i_Range, out float type)))
            {
                throw new FormatException();
            }
            if (!(type >= i_Min && type <= i_Max))
            {
                throw new GarageLogicException.ValueOutOfRangeException(i_Min, i_Max);
            }

            return success;
        }

        public static bool Validfloat(string i_numberinput)
        {
            if (!(float.TryParse(i_numberinput, out float usernumber)))
            {
                throw new FormatException();
            }

            return true;
        }

        public static bool ValidInt(string i_NumberInput)
        {
            if (!(int.TryParse(i_NumberInput, out int userNumber)))
            {
                throw new FormatException();
            }

            return true;
        }
    }
}
