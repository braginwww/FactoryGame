IFactory humanFactory = new HumanFactory();
IFactory zombieFactory = new ZombieFactory();

Game game = new Game(humanFactory, zombieFactory);
game.Start();

Console.WriteLine("Нажмите Enter для выхода...");
Console.ReadLine();