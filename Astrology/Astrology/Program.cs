using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrology
{
    class Program
    {
        static void Main(string[] args)
        {
            string ans = "yes", name, birthdate;
            int bm, by; //birthday, birthmonth, birthyear
            DateTime bd;

            while (GetYesNo("Would you like to get your Astrological personality traits? "))
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                bd = GetDate("Enter Birthdate: ", "Invalid Birthdate");
                int d = Days(bd);
                int m = Months(bd);
                int y = Years(bd);
                int nDays = numDays(bd);
                string zres = Zresults(bd);
                string traits = Traits(bd);
                Console.WriteLine("Thank you, " + name + ". Based on the information provided, I can tell you the following: \n \t");
                Console.WriteLine("You are " + y + " years, " + m + " months, " + d + " days old.\n\tThere are " + nDays + " days until your next birthday. \n\tYou were born under the sign of " + zres + "\n\tYou have the following " +
                "Personality Traits: \n\t" + traits + "\n");
            }
        }
        static string GetString(string prompt, string[] valid, string error)
        {
            // prompt=user prompt, valid=array responses, error=msg to display on invalid entry
            //ALL STRINGS RETURNED UPPER CASE. ALL valid[] ENTRIES MUST BE IN UPPER CASE
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);
            } while (!OK);
            return response;
        }
        static bool GetYesNo(string prompt) // GET YES/NO OR Y/N RESPONSE. RETURN TRUE FOR YES/Y, FALSE FOR NO/N
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");
        }
        static DateTime GetDate(string prompt, string error)
        {
            DateTime result;
            string userInput;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                OK = DateTime.TryParse(userInput, out result);
                if (!OK) Console.WriteLine(error);
            }
            while (!OK);
            return result;
        }
        static int Days(DateTime birthdate)
        {
            DateTime temp = birthdate;
            int Udays = 0; //your days left to next birthday
            while (temp.Day < DateTime.Today.Day)
            {
                Udays++;
                temp = temp.AddDays(1);
            }
            return Udays;
        }
        static int Months(DateTime birthdate)
        {
            DateTime temp = birthdate;
            int Umonths = 0; //your months left to next birthday
            while (temp.Month < DateTime.Today.Month)
            {
                Umonths++;
                temp = temp.AddMonths(1);
            }
            return Umonths;
        }
        static int Years(DateTime birthdate)
        {
            DateTime temp = birthdate;
            int Uyears = 0; //your years left to next birthday
            while (temp.Year < DateTime.Today.Year)
            {
                Uyears++;
                temp = temp.AddYears(1);
            }
            return Uyears;
        }

        static string Zresults(DateTime birthdate)
        {
            DateTime bd = birthdate;
            DateTime t = DateTime.Today;
            string a = "";
            string[] sign = { " Capricorn", "Aquarius", "Pisces", "Aries", "Taurus",
                                "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Saggitarius" };
            switch (bd.Month)
            {
                case 1:
                    if (bd.Day <= 20)
                        a = sign[0];
                    else
                        a = sign[1];
                    break;
                case 2:
                    if (bd.Day <= 20)
                        a = sign[1];
                    else
                        a = sign[2];
                    break;
                case 3:
                    if (bd.Day <= 21)
                        a = sign[2];
                    else
                        a = sign[3];
                    break;
                case 4:
                    if (bd.Day <= 20)
                        a = sign[3];
                    else
                        a = sign[4];
                    break;
                case 5:
                    if (bd.Day <= 20)
                        a = sign[4];
                    else
                        a = sign[5];
                    break;
                case 6:
                    if (bd.Day <= 20)
                        a = sign[5];
                    else
                        a = sign[6];
                    break;
                case 7:
                    if (bd.Day <= 20)
                        a = sign[6];
                    else
                        a = sign[7];
                    break;
                case 8:
                    if (bd.Day <= 20)
                        a = sign[7];
                    else
                        a = sign[8];
                    break;
                case 9:
                    if (bd.Day <= 20)
                        a = sign[8];
                    else
                        a = sign[9];
                    break;
                case 10:
                    if (bd.Day <= 20)
                        a = sign[9];
                    else
                        a = sign[10];
                    break;
                case 11:
                    if (bd.Day <= 20)
                        a = sign[10];
                    else
                        a = sign[11];
                    break;
                case 12:
                    if (bd.Day <= 20)
                        a = sign[11];
                    else
                        a = sign[0];
                    break;
            }
            return a;
        }
        static string Traits(DateTime birthDate)
        {
            DateTime bd = birthDate;
            DateTime t = DateTime.Today;
            string h = "";
            string[] horo = {
 // Capricorn Dec 23-Jan 20
" Practical and prudent\n"+ 
"         Ambitious and disciplined\n"+ 
"         Patient and careful\n"+ 
"         Humorous and reserved\n\n"+ 
"         Pessimistic and fatalistic\n"+ 
"         Miserly and grudging\n"+



"Zodiac personallity traits\n"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Aquarius Jan 21-Feb 19
" Friendly and humanitarian\n"+ 
"         Honest and loyal\n"+ 
"         Original and inventive\n"+ 
"         Independent and intellectual\n\n"+ 
"         Intractable and contrary\n"+ 
"         Perverse and unpredictable\n"+ 
"         Unemotional and detached\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Pisces Feb 20-Mar 20
" Imaginative and sensitive\n"+ 
"         Compassionate and kind\n"+ 
"         Selfless and unworldly\n"+ 
"         Intuitive and sympathetic\n\n"+ 
"         Escapist and idealistic\n"+ 
"         Secretive and vague\n"+ 
"         Weak-willed and easily led\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// 0 Aries Mar 21 - Apr 20
" Aventurous and energetic\n"+
"         Pioneering and courageous\n"+
"         Enthusiastic and confident\n"+
"         Dynamic and quick-witted\n\n"+ 
"         Selfish and quick-tempered\n"+
"         Impulsive and impatient\n"+
"         Foolhardy and daredevil\n"+



"Zodiac personallity traits" +
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Taurus Apr 21-May 21
" Patient and reliable\n"+
"         Warmhearted and loving\n"+
"         Persistent and determined\n"+
"         Placid and security loving\n\n"+
"         Jealous and possessive\n"+
"         Resentful and inflexible\n"+
"         Self-indulgent and greedy\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",
 
// Gemini May 22-Jun 21
" Adaptable and versatile\n"+
"         Communicative and witty\n"+
"         Intellectual and eloquent\n"+
"         Youthful and lively\n\n"+
"         Nervous and tense\n"+
"         Superficial and inconsistent\n"+
"         Cunning and inquisitive\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Cancer Jun 22-Jul 22
"Emotional and loving\n"+
"         Intuitive and imaginative\n"+
"         Shrewd and cautious\n"+
"         Protective and sympathetic\n\n"+
"         Changeable and moody\n"+
"         Overemotional and touchy\n"+
"         Clinging and unable to let go\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Leo  Jul 23-Aug 21
" Generous and warmhearted\n"+
"         Creative and enthusiastic\n"+
"         Broad-minded and expansive\n"+
"         Faithful and loving\n\n"+
"         Pompous and patronizing\n"+
"         Bossy and interfering\n"+
"         Dogmatic and intolerant\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Virgo Aug 22-Sep 23
" Modest and shy\n"+ 
"         Meticulous and reliable\n"+ 
"         Practical and diligent\n"+
"         Intelligent and analytical\n\n"+
"         Fussy and a worrier\n"+
"         Overcritical and harsh\n"+ 
"         Perfectionist and conservative\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Libra Sep 24-Oct 23
"         Diplomatic and urbane\n"+ 
"         Romantic and charming\n"+ 
"         Easygoing and sociable\n"+ 
"         Idealistic and peaceable\n\n"+ 
"         Indecisive and changeable\n"+ 
"         Gullible and easily influenced\n"+
"         Flirtatious and self-indulgent\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Scorpio Oct 24-Nov 22
" Determined and forceful\n"+ 
"         Emotional and intuitive\n"+ 
"         Powerful and passionate\n"+ 
"         Exciting and magnetic\n\n"+ 
"         Jealous and resentful\n"+ 
"         Compulsive and obsessive\n"+ 
"         Secretive and obstinate\n"+



"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n",

// Sagittarius Nov 23-Dec 22
" Optimistic and freedom-loving\n"+ 
"         Jovial and good-humored\n"+ 
"         Honest and straightforward\n"+ 
"         Intellectual and philosophical\n\n"+ 
"         Blindly optimistic and careless\n"+ 
"         Irresponsible and superficial\n"+ 
"         Tactless and restless\n"+
                                 
                                 
 
"Zodiac personallity traits"+
"Source:  http://nuclear.ucdavis.edu/~rpicha/personal/astrology/ \n"};
            switch (bd.Month)
            {
                case 1:
                    if (bd.Day <= 20)
                        h = horo[0];
                    else
                        h = horo[1];
                    break;
                case 2:
                    if (bd.Day <= 19)
                        h = horo[1];
                    else
                        h = horo[2];
                    break;
                case 3:
                    if (bd.Day <= 20)
                        h = horo[2];
                    else
                        h = horo[3];
                    break;
                case 4:
                    if (bd.Day <= 20)
                        h = horo[3];
                    else
                        h = horo[4];
                    break;
                case 5:
                    if (bd.Day <= 21)
                        h = horo[4];
                    else
                        h = horo[5];
                    break;
                case 6:
                    if (bd.Day <= 20)
                        h = horo[5];
                    else
                        h = horo[6];
                    break;
                case 7:
                    if (bd.Day <= 20)
                        h = horo[6];
                    else
                        h = horo[7];
                    break;
                case 8:
                    if (bd.Day <= 20)
                        h = horo[7];
                    else
                        h = horo[8];
                    break;
                case 9:
                    if (bd.Day <= 20)
                        h = horo[8];
                    else
                        h = horo[9];
                    break;
                case 10:
                    if (bd.Day <= 20)
                        h = horo[9];
                    else
                        h = horo[10];
                    break;
                case 11:
                    if (bd.Day <= 20)
                        h = horo[10];
                    else
                        h = horo[11];
                    break;
                case 12:
                    if (bd.Day <= 20)
                        h = horo[11];
                    else
                        h = horo[0];
                    break;
            }
            return h;
        }
        static int numDays(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            DateTime yours = new DateTime(today.Year, birthdate.Month, birthdate.Day);

            if (yours < today)
                yours = yours.AddYears(1);

            int numDays = (yours - today).Days;
            return numDays;
        }
    }
}