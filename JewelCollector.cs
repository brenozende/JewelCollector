namespace JewelCollector;

public class JewelCollector
{
    Map m;

    public JewelCollector(Robot r, int level) {
        if (level <= 20){
            m = new Map(10 + level,10 + level);
        }
        else {
            m = new Map(30,30);
        }
        m.InsertEntity(0,0,r);
        m.GenerateEntities();
    }
    public static void Main() {
  
        bool running = true;
        bool newGame = true;
        int level = 0;
        //KeyListener keyListener = new KeyListener();
        // keyListener.KeyPressed += // Método a ser executado
        Robot r = new Robot();
        
        do {
            running = true;
            r.energy =  5;
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
                if(r.energy <= 0) {
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
