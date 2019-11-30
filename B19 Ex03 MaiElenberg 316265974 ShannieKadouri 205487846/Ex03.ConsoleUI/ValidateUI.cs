using System;

namespace ConsoleUI
{
    internal class ValidateUI
    {

        internal static int ValidateWelcomeAndInfoMsg(string i_WelcomeInput)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    bool success = GarageLogicValidation.Validation.ValidateRangeInt(i_WelcomeInput, 1, 4);
                }
                catch(FormatException error)
                {
                    System.Console.WriteLine("Invalid input- Please select 1, 2, 3 or 4");
                    i_WelcomeInput = System.Console.ReadLine();
                    continue;
                }
                catch(GarageLogicException.ValueOutOfRangeException error)
                {
                    System.Console.WriteLine("Invalid input- Please select 1, 2, 3 or 4");
                    i_WelcomeInput = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }

            return int.Parse(i_WelcomeInput);
        }

        internal static int ValidateInt(string i_Range, int i_Min, int i_Max)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    GarageLogicValidation.Validation.ValidateRangeInt(i_Range, i_Min, i_Max);
                }
                catch (FormatException error)
                {
                    System.Console.WriteLine("Invalid input- Please insert a valid input");
                    i_Range = System.Console.ReadLine();
                    continue;
                }
                catch (GarageLogicException.ValueOutOfRangeException error)
                {
                    System.Console.WriteLine(error.Message);
                    i_Range = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }
            return int.Parse(i_Range);
        }

        internal static float ValidateFloat(string i_Range, float i_Min, float i_Max)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    GarageLogicValidation.Validation.ValidateRangeFloat(i_Range, i_Min, i_Max);
                }
                catch (FormatException error)
                {
                    System.Console.WriteLine("Invalid input- Please insert a valid input");
                    i_Range = System.Console.ReadLine();
                    continue;
                }
                catch (GarageLogicException.ValueOutOfRangeException error)
                {
                    System.Console.WriteLine(error.Message);
                    i_Range = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }
            return float.Parse(i_Range);
        }

        internal static string ValidateInt(string i_Input)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    GarageLogicValidation.Validation.ValidInt(i_Input);
                }
                catch (FormatException error)
                {
                    System.Console.WriteLine("Invalid input- Please insert a valid input");
                    i_Input = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }

            return i_Input;
        }


        internal static string ValidateFloat(string i_Input)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    GarageLogicValidation.Validation.Validfloat(i_Input);
                }
                catch (FormatException error)
                {
                    System.Console.WriteLine("Invalid input- Please insert a valid input");
                    i_Input = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }
            return i_Input;
        }

        internal static string ValidateString(string i_UserInput)
        {
            while (i_UserInput.Equals(""))
            {
                System.Console.WriteLine("Please write an answer to the requested question");
                i_UserInput = System.Console.ReadLine();
            }

            return i_UserInput;
        }

        internal static string ValidatePhoneNumber(string i_PhoneNumber)
        {
            bool flag = false;
            while(!flag)
            {
                foreach (Char c in i_PhoneNumber)
                {
                    if (!Char.IsDigit(c))
                    {
                        System.Console.WriteLine("Please enter a valid phone number");
                        i_PhoneNumber = System.Console.ReadLine();
                    }
                    break;
                }
                flag = true;
            }

            return i_PhoneNumber;
        }

        internal static int ValidateFuelType(string i_FuelType, int i_AcctualFuelType)
        {
            bool flag = false;
            int fuelType = 0;
            while(!flag)
            {
                fuelType = ValidateInt(i_FuelType,
                        1, Enum.GetNames(typeof(GarageLogicEnergy.FuelVehicle.eFuelType)).Length);

                if (fuelType != i_AcctualFuelType)
                {
                    System.Console.WriteLine("Invalid input! Please type the right fuel type (" + i_AcctualFuelType + ")");
                    i_FuelType = System.Console.ReadLine();
                    continue;
                }
                flag = true;
            }
            return fuelType;
        }
    }
}
