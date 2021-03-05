using System;

namespace Game_Millioner
{
    public class QuestAnsw
    {
        public QuestAnsw(string question, string answ1, string answ2, string answ3, string answ4, int correctAnsw)
        {
            this.question = question; // это конструктор
            this.answ1 = answ1;
            this.answ2 = answ2;
            this.answ3 = answ3;
            this.answ4 = answ4;
            this.correctAnsw = correctAnsw;
        }

        public string question; // это поля класса
        public string answ1;
        public string answ2;
        public string answ3;
        public string answ4;
        public int correctAnsw;

        public void Ask() // задать вопрос и дать 4 вар-та ответа
        {
            Console.WriteLine(question);
            Console.WriteLine($"{answ1}\t{answ2}\n{answ3}\t{answ4}");
        }

        public uint GetAnsw(string userAnswer) // получить ответ от игрока
        {
            // userAnswer = Console.ReadLine();
            uint userAnswerInt = Convert.ToUInt32(userAnswer);
            return userAnswerInt;
        }

        public bool AnalyzeAnsw(uint userAnswInt) // проверить ответ на правильность и дать приз
        {
            bool result;

            if (userAnswInt > 0 && userAnswInt < 5)
            {
                if (userAnswInt != correctAnsw)
                {
                    result = false;
                    Console.WriteLine("Неверно. Вы покидаете игру ни с чем.");
                }
                else
                {
                    result = true;
                }
                return result;
            }
            else
            {
                if (userAnswInt > 5)
                {
                    Console.WriteLine("Введите ответ, используя только цифры 1, 2, 3 или 4");
                    string repeatEnter = Console.ReadLine();
                    userAnswInt = Convert.ToUInt32(repeatEnter);

                }
                return AnalyzeAnsw(userAnswInt);

            }
        }

        public bool LetsMorePlay() // хочет ли продолжить игру
        {
            bool result;
            Console.WriteLine($"Играем дальше? YES or NO?");
            string play = Console.ReadLine();
            if (play.ToLower() == "no")
            {
                result = false;
            }
            else
            {
                if (play.ToLower() == "yes")
                {
                    result = true;
                }
                else
                {
                    if (play.ToLower() != "yes" || play.ToLower() != "no")
                    {
                        Console.WriteLine("Введите корректно ответ.");
                    }
                    return LetsMorePlay();
                }
            }
            return result;
        }
    }
}


