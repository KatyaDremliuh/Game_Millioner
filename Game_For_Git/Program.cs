using System;

namespace Game_Millioner
{
    class Program
    {
        static int IncreaseThePrize(int prize) // функция удвоение приза
        {
            return prize * 2;
        }
        static void Main(string[] args)
        {
            int prize = 100;
            Console.WriteLine("Вас приветствует игра \"Кто хочет стать миллионером\". Вам будут заданы вопросы и" +
            "предложены 4 варианта ответа, где правильный ответ только один. " +
            "Первый правильный ответ приносит 100 BYN, каждый следующий верный ответ" +
            "удваивает сумму выигрыша.");
            Console.WriteLine("Введите Ваше имя.");
            string name = Console.ReadLine();
            Console.WriteLine($"{name}, начинаем игру!");
            QuestAnsw[] questions = new QuestAnsw[5];
            questions[0] = new QuestAnsw("Как называется жидкое косметическое средство для мытья волос?",
            "1 - Шампунь", "2 - Мыло", "3 - Тряпка", "4 - Порошок", 1);
            questions[1] = new QuestAnsw("Из скольких месяцев состоит год?",
            "1 - Из 9", "2 - Из 12", "3 - Из 4", "4 - Не состоит", 2);
            questions[2] = new QuestAnsw("Как называется подвидный холм песка в пустыне?",
            "1 - Гора", "2 - Утёс", "3 - Скала", "4 - Дюна", 4);
            questions[3] = new QuestAnsw("Как называется помещение в судне, где живут матросы?",
            "1 - Дом", "2 - Квартира", "3 - Кубрик", "4 - Кабинет", 3);
            questions[4] = new QuestAnsw("Какой прибор помогает изучать морское дно?",
            "1 - Батискаф", "2 - Дирижабль", "3 - Телескоп", "4 - Луноход", 1);

            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].Ask(); // задали вопрос
                string usersAnsw = Console.ReadLine();
                uint userAnswInt = questions[i].GetAnsw(usersAnsw); // игрок ввел ответ
                bool resultOfAnalyse = questions[i].AnalyzeAnsw(userAnswInt); // проверили ответ на правильность

                if (resultOfAnalyse == false) // закончили задавать вопросы после неправильного ответа
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Верно! Вы получаете {prize} BYN");
                    prize = IncreaseThePrize(prize);
                }

                if (i == questions.Length - 1) // задать последний вопрос
                {
                    Console.WriteLine($"{name}, вы ответили на все вопросы и уходите с призом в {prize / 2} BYN");
                }
                else
                {
                    bool resultOfPlaing = questions[i].LetsMorePlay(); // вызываем функцию "хочет ли продолжить игру"
                    if (resultOfPlaing == false) // если не хочет - выгнать вон
                    {
                        Console.WriteLine($"Спасибо за игру. Вы уходите с {prize / 2} BYN");
                        break;
                    }
                }
            }
        }
    }
}
