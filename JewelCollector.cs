namespace JewelCollector;

public class JewelCollector
{
    Map m;

    public JewelCollector(Robot r, int level) {
        m = new Map(10 + level,10 + level);
        m.InsertEntity(0,0,r);
        m.GenerateEntities();
        // m.InsertEntity(1, 9, new RedJewel());
        // m.InsertEntity(8, 8, new RedJewel());
        // m.InsertEntity(9, 1, new GreenJewel());
        // m.InsertEntity(7, 6, new GreenJewel());
        // m.InsertEntity(3, 4, new BlueJewel());
        // m.InsertEntity(2, 1, new BlueJewel());
        // m.InsertEntity(5, 0, new Water());
        // m.InsertEntity(5, 1, new Water());
        // m.InsertEntity(5, 2, new Water());
        // m.InsertEntity(5, 3, new Water());
        // m.InsertEntity(5, 4, new Water());
        // m.InsertEntity(5, 5, new Water());
        // m.InsertEntity(5, 6, new Water());
        // m.InsertEntity(5, 9, new Tree());
        // m.InsertEntity(3, 9, new Tree());
        // m.InsertEntity(8, 3, new Tree());
        // m.InsertEntity(2, 5, new Tree());
        // m.InsertEntity(1, 4, new Tree());
        // m.InsertEntity(2, 7, new Tree());
        // m.InsertEntity(3, 6, new Tree());
        
    }
    public static void Main() {
  
        bool running = true;
        bool newGame = true;
        int level = 0;
        //KeyListener keyListener = new KeyListener();
        // keyListener.KeyPressed += // Método a ser executado
        
        do {
            running = true;
            Robot r = new Robot();
            JewelCollector game = new JewelCollector(r, level);
    
            do {
                game.m.PrintMap();
                r.PrintInfos();
                Console.WriteLine("Enter the command: ");
                string command = Console.ReadLine();
  
                if (command.Equals("quit")) {
                    running = false;
                    newGame = false;
                } else if (command.Equals("w")) {
                    game.m.MoveRobotUp(r);
                } else if (command.Equals("a")) {
                    game.m.MoveRobotLeft(r);
                } else if (command.Equals("s")) {
                    game.m.MoveRobotDown(r);
                } else if (command.Equals("d")) {
                    game.m.MoveRobotRight(r);
                } else if (command.Equals("g")) {
                    game.m.CollectItens(r);
                } else if (command.Equals("next")){
                    running = false;
                }

                if(game.m.remainingJewels == 0) {
                    running = false;
                }
                if(r.energy == 0) {
                    running = false;
                    newGame = false;
                }
            } while (running);
            Console.WriteLine("Level finished");
            level += 1;
            r.PrintInfos();
        } while (newGame);
        Console.WriteLine("Game Over");
    }
}
