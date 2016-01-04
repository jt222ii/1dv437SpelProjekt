﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.MapCreator
{
    class LevelCreator
    {
        /*
         * # = regular tile
         * K = key
         * > = turret facing right
         * < = turret facing left
         * D = door
         * $ = spawn point
         * * = saw blade
         */ 
        public List<char[,]> getLevels()
        {
            List<char[,]> levels = new List<char[,]>();
            /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
            char[,] Level1 = {
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','$','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','#','#','#','.','.','.','.','.','.','.','.','.','#','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','D','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','#','#','#','.','.','.','.','.','#','#','#','.','#','.','.','.','#','#','#','#','#','.','.','.','.','.','.','.'},
                              {'.','.','.','.','#','.','#','.','.','.','.','.','#','.','.','.','#','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','#','#','.','#','#','#','.','#','#','#','.','.','.','.','#','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','#','#','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','K','.','.','.','.','#','#','#','#','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','#','.','.','.','.','.','.','.','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','D','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','#','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                             };
            /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
            char[,] Level2 = {
                              {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                              {'#','>','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                              {'#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','#','#','#','.','.','#','#','#','#','.','#'},
                              {'#','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#','.','#','#','#','#','.','.','#','.','#'},
                              {'#','K','.','.','.','.','.','.','.','.','.','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                              {'#','.','.','.','.','.','.','.','.','#','#','#','.','#','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                              {'#','.','.','.','#','#','#','#','#','#','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','#'},
                              {'#','.','.','.','#','#','.','.','#','#','#','#','#','#','#','#','#','#','.','.','.','#','.','.','.','.','.','.','.','.','.','#'},
                              {'#','.','#','#','#','#','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','#','.','#','#','#','#','#','#','.','.','#'},
                              {'#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','#','.','.','.','.','#','.','<','.','.','#'},
                              {'#','#','#','#','#','#','#','#','#','#','#','#','.','.','.','#','#','#','.','#','#','#','#','#','#','.','#','#','#','.','.','#'},
                              {'#','.','.','.','.','.','.','.','.','.','.','#','.','.','.','>','.','#','.','.','.','#','.','.','.','.','#','.','#','.','.','#'},
                              {'#','.','.','.','.','.','.','.','.','.','.','#','#','.','.','#','#','#','#','#','.','#','.','#','#','#','#','.','#','.','.','#'},
                              {'#','.','.','.','.','#','#','#','#','#','.','#','.','.','#','#','.','#','.','.','.','#','.','.','.','.','#','.','#','.','.','#'},
                              {'#','.','.','.','.','#','.','.','.','.','.','#','.','.','#','.','.','#','.','#','#','#','#','#','#','.','#','.','#','.','.','#'},
                              {'#','.','.','.','#','#','.','.','#','#','#','#','.','#','#','.','.','#','.','.','.','.','.','.','.','.','#','.','#','.','.','#'},
                              {'#','.','$','.','#','.','.','.','.','.','.','.','.','#','.','.','.','#','#','#','#','#','#','#','#','#','#','.','#','.','D','#'},
                              {'#','#','#','#','#','.','.','#','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#'},
                             };
            /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
            char[,] Level3 = {
                              {'#','#','#','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'#','>','.','.','.','.','.','K','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'#','#','.','.','.','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','.','.','.'},
                              {'.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','*','.','.','.'},
                              {'.','.','.','.','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','*','.','.','.','.'},
                              {'.','.','.','.','.','#','#','#','#','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','*','.','.','.','.','.'},
                              {'.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','*','.','.','.','.','.','.'},
                              {'.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','*','.','.','.','.','.','.','.'},
                              {'.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','*','.','.','.','.','.','.','.','#','#','#','#','#','.','.','.'},
                              {'.','.','.','.','.','.','#','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','.','.','#'},
                              {'.','.','.','.','.','.','.','#','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                              {'.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#'},
                              {'.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','D','.','.','.','.','.','<','.','.','.','.','$','#'},
                              {'.','.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                             };
            /*------------------------------------------------------------------------------------------------------------------------------------------------------*/

            /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
            levels.Add(Level1);
            levels.Add(Level2);
            levels.Add(Level3);


            return levels;
        }
    }
}
