using System.Collections;

namespace JewelCollector;

public class Map
{
    public int remainingJewels = 0;
    Entity[,] map;

    public Map(int height, int widght) {
        map = new Entity[height, widght];
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < widght; j++) {
                map[i,j] = new OpenPath();
            }
        }
    }
    public void PrintMap() {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                Console.Write(map[i,j]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }
        Console.Write("\n");
        Console.WriteLine("Remaining Jewels: " + remainingJewels);
    }
    
    public void InsertEntity(int x, int y, Entity e) {
        map[x, y] = e;
        if(typeof(Jewel).IsInstanceOfType(e)) {
            remainingJewels += 1;
        }
    }

    private Entity GenerateRandomEntity(int level) {
        Random rnd = new Random();
        int modifier = 0;
        if(level >= 2) {
            modifier = 1;
        }
        int num = rnd.Next(5 + modifier);
        switch (num)
        {
            case 0: return new Tree();
            case 1: return new Water();
            case 2: 
                remainingJewels += 1;
                return new BlueJewel();
            case 3: 
                remainingJewels += 1;
                return new GreenJewel();
            case 4: 
                remainingJewels += 1;
                return new RedJewel();
            case 5:
                return new Radiation();
            default: return new Water();
        }
    }

    public void GenerateEntities() {
        int max = map.GetLength(0);
        int x;
        int y;
        for(int i = 0; i < max*max*0.33 ; i++) {
            Random rnd = new Random();
            do {
                x = rnd.Next(max);
                y = rnd.Next(max);
            } while (!typeof(OpenPath).IsInstanceOfType(map[x,y]));
            map[x, y] = GenerateRandomEntity(max - 9);
        }
    }

    private (int, int) FindRobot() {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                if (typeof(Robot).IsInstanceOfType(map[i,j])) {
                    return (i, j);
                }
            }
        }
        return (0,0);
    }

    private Boolean IsTransitable(Entity e){
        if (typeof(OpenPath).IsInstanceOfType(e) || typeof(Radiation).IsInstanceOfType(e)) {
            return true;
        }
        return false;
    }

    private Boolean IsRadiation(Entity e) {
        if(typeof(Radiation).IsInstanceOfType(e)) {
            return true;
        }
        return false;
    }

    private Boolean HasAdjacentRadiation(Entity[,] map, int x, int y) {
        if(
            (x > 1) && (IsRadiation(map[x - 1, y])) ||
            (x < map.GetLength(0) - 1) && (IsRadiation(map[x + 1, y])) ||
            (y > 1) && (IsRadiation(map[x, y - 1])) || 
            (y < map.GetLength(0) - 1) && (IsRadiation(map[x, y + 1]))) {
            return true;
         }
         return false;
    }

    public void MoveRobotUp(Robot robot) {
        (int, int) robotPosition = FindRobot();
        int x = robotPosition.Item1;
        int y = robotPosition.Item2;
        try{
            if(IsTransitable(map[x - 1, y]) && robot.energy != 0) {
                if(IsRadiation(map[x - 1, y])) {
                    robot.energy -= 30;
                }
                if (HasAdjacentRadiation(map, x-1, y)) {
                    robot.energy -= 10;
                }
                map[x, y] = new OpenPath();
                map[x - 1, y] = robot;
                robot.energy-=1;
            }
            else {
                throw new NonTransitableException();
            }
        } catch (IndexOutOfRangeException e) {
            Console.WriteLine("Falha na movimentação: fora dos limites do mapa, tente novamente\n");
        } catch (NonTransitableException e) {
            Console.WriteLine("Posição já ocupada por outra entidade, tente outro comando.\n");
        }
    }

    public void MoveRobotLeft(Robot robot) {
        (int, int) robotPosition = FindRobot();
        int x = robotPosition.Item1;
        int y = robotPosition.Item2;
        try{
            if(IsTransitable(map[x, y - 1]) && robot.energy != 0) {
                if(IsRadiation(map[x, y - 1])) {
                    robot.energy -= 30;
                }
                if (HasAdjacentRadiation(map, x, y - 1)) {
                    robot.energy -= 10;
                }
                map[x, y] = new OpenPath();
                map[x, y - 1] = robot;
                robot.energy-=1;
            }
            else {
                throw new NonTransitableException();
            }
        } catch (IndexOutOfRangeException e) {
            Console.WriteLine("Falha na movimentação: fora dos limites do mapa, tente outro comando.\n");
        } catch (NonTransitableException e) {
            Console.WriteLine("Posição já ocupada por outra entidade, tente outro comando.\n");
        }
    }

    public void MoveRobotRight(Robot robot) {
        (int, int) robotPosition = FindRobot();
        int x = robotPosition.Item1;
        int y = robotPosition.Item2;
        try {
            if(IsTransitable(map[x, y + 1]) && robot.energy != 0) {
                if(IsRadiation(map[x, y + 1])) {
                    robot.energy -= 30;
                }
                if (HasAdjacentRadiation(map, x, y + 1)) {
                    robot.energy -= 10;
                }
                map[x, y] = new OpenPath();
                map[x, y + 1] = robot;
                robot.energy-=1;
            }
            else {
                throw new NonTransitableException();
            }
        } catch (IndexOutOfRangeException e) {
            Console.WriteLine("Falha na movimentação: fora dos limites do mapa, tente novamente\n");
        } catch (NonTransitableException e) {
            Console.WriteLine("Posição já ocupada por outra entidade, tente outro comando.\n");
        }
    }

    public void MoveRobotDown(Robot robot) {
        (int, int) robotPosition = FindRobot();
        int x = robotPosition.Item1;
        int y = robotPosition.Item2;
        try {
            if(IsTransitable(map[x + 1, y]) && robot.energy != 0) {
                if(IsRadiation(map[x + 1, y])) {
                    robot.energy -= 30;
                }
                if (HasAdjacentRadiation(map, x + 1, y)) {
                    robot.energy -= 10;
                }
                map[x, y] = new OpenPath();
                map[x + 1, y] = robot;
                robot.energy-=1;
            }
            else {
                throw new NonTransitableException();
            }
        } catch (IndexOutOfRangeException e) {
            Console.WriteLine("Falha na movimentação: fora dos limites do mapa, tente novamente\n");
        } catch (NonTransitableException e) {
            Console.WriteLine("Posição já ocupada por outra entidade, tente outro comando.\n");
        }
    }

    private void Collect(int x, int y, Robot r, int rx, int ry) {
        if(typeof(Tree).IsInstanceOfType(map[rx + x, ry + y])) {
            r.energy += 3;
            map[rx + x, ry + y] = new OpenPath();
        }
        else if (typeof(BlueJewel).IsInstanceOfType(map[rx + x, ry + y])) {
            r.energy += 5;
            r.itens.Add(map[rx + x, ry + y]);
            map[rx + x, ry + y] = new OpenPath();
            remainingJewels -= 1;
        }
        else if (typeof(Jewel).IsInstanceOfType(map[rx + x, ry + y])) {
            r.itens.Add(map[rx + x, ry + y]);
            map[rx + x, ry + y] = new OpenPath();
            remainingJewels -= 1;
        }

        
    }

    public void CollectItens(Robot r) {
        (int, int) robotPosition = FindRobot();
        int x = robotPosition.Item1;
        int y = robotPosition.Item2;
        if (x == 0) {
            if (y == 0) {
                Collect(0, 1, r, x, y);
                Collect(1, 0, r, x, y);
            }
            else if (y == map.GetLength(0) - 1) {
                Collect(0, -1, r, x, y);
                Collect(1, 0, r, x, y);
            }
            else {
                Collect(0, -1, r, x, y);
                Collect(1, 0, r, x, y);
                Collect(0, 1, r, x, y);
            }
        }
        else if (x == map.GetLength(0) - 1) {
            if (y == 0) {
                Collect(-1, 0, r, x, y);
                Collect(0, 1, r, x, y);
            }
            else if (y == map.GetLength(0) - 1) {
                Collect(0, -1, r, x, y);
                Collect(-1, 0, r, x, y);
            }
            else {
                Collect(0, -1, r, x, y);
                Collect(-1, 0, r, x, y);
                Collect(0, 1, r, x, y);
            }
        }
        else {
            if (y == 0) {
                Collect(-1, 0, r, x, y);
                Collect(0, 1, r, x, y);
                Collect(1, 0, r, x, y);
            }
            else if (y == map.GetLength(0) - 1) {
                Collect(-1, 0, r, x, y);
                Collect(0, -1, r, x, y);
                Collect(1, 0, r, x, y);
            }
            else {
                Collect(-1, 0, r, x, y);
                Collect(0, -1, r, x, y);
                Collect(0, 1, r, x, y);
                Collect(1, 0, r, x, y);
            }
        }
    }
}
