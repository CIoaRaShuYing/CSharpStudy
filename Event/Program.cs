namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Dog dog = new Dog();
            dog.name = "大黄";
            Cat cat = new Cat();
            cat.name = "哈基米";
            Panda panda = new Panda();
            panda.name = "丫丫";

            person.PrepareFood();

            person.OnFeed += dog.EatFood;
            person.OnFeed += cat.EatFood;
            person.OnFeed += panda.EatFood;

            person.DoFeed();
        }
    }

    class FeedEventArgs
    {
        public string? food_dog;
        public string? food_cat;
        public string? food_panda;
    }
    class Person
    {
        public event EventHandler<FeedEventArgs> OnFeed;
        public string[] food =new string[3];

        public void DoFeed()
        {
            if (OnFeed != null)
            {
                FeedEventArgs e = new FeedEventArgs();
                e.food_dog = food[0];
                e.food_cat = food[1];
                e.food_panda = food[2];
                OnFeed(this, e);
            }
        }
        public void PrepareFood()
        {
            Console.WriteLine("今天给大黄吃什么？");
            string? food1 = Console.ReadLine();
            Console.WriteLine("今天给哈基米吃什么？");
            string? food2 = Console.ReadLine();
            Console.WriteLine("今天给丫丫吃什么？");
            string? food3 = Console.ReadLine();
            Console.WriteLine();
            food[0] = food1;
            food[1] = food2;
            food[2] = food3;
        }
    }

    class Animal
    {
        public string? name;
        public string? favouriteFood;
    }
    class Dog : Animal
    {
        public new string favouriteFood = "大骨棒";
        public void EatFood(object sender, FeedEventArgs args)
        {
            if (args.food_dog == null || args.food_dog =="")
            {
                Console.WriteLine($"{name}看到饭盆里没有食物，咬了主人一口。");
            }
            else
            {
                if (favouriteFood != args.food_dog)
                {
                    Console.WriteLine($"{name}不想吃{args.food_dog},绝食啦！");
                }
                else
                {
                    Console.WriteLine($"{name}吃的很香...");
                }
            }
        }
    }
    class Cat : Animal
    {
        public new string favouriteFood = "鱼摆摆";
        public void EatFood(object sender, FeedEventArgs args)
        {
            if (args.food_cat == null || args.food_cat == "")
            {
                Console.WriteLine($"{name}看到饭盆里没有食物，化身猫娘向主人撒娇，以下省略一万字...");
            }
            else
            {
                if (favouriteFood != args.food_cat)
                {
                    Console.WriteLine($"{name}不想吃{args.food_cat},绝食啦！");
                }
                else
                {
                    Console.WriteLine($"{name}吃的很香...");
                }
            }
        }
    }
    class Panda : Animal
    {
        public new string favouriteFood = "社会主义的铁拳";
        public void EatFood(object sender, FeedEventArgs args)
        {
            if (args.food_panda == null || args.food_panda == "")
            {
                Console.WriteLine($"{name}看到饭盆里没有食物，留下了悔恨的泪水，想念起了资本主义的糖衣炮弹");
            }
            else
            {
                if (favouriteFood != args.food_panda)
                {
                    Console.WriteLine($"{name}不想吃{args.food_panda},绝食啦！");
                }
                else
                {
                    Console.WriteLine($"{name}吃的很香...");
                }
            }
        }
    }
}
