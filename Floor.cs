﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor
    {
        public GameObject GameObject { get; set; }
        public Boolean IsVoid { get; set; }
        public Boolean IsFloor { get; set; }

        public Boolean isDesitination { get; set; }
        public Floor North {get; set;}
        public Floor South {get; set;}
        public Floor West {get; set;}
        public Floor East {get; set;}


        public void setContent(char type)
        {
            switch (type)
            {
                
                case '#':
                    GameObject = new Wall('#');
                    break;
                case '@':
                    GameObject = new Player('@', this);
                    break;
                    
                case 'o':
                    GameObject = new Chest('o', this);
                    break;
                    
                case 'x':
                    isDesitination = true;
                    break;

                case '.':
                    IsFloor = true;
                    break;

                default: IsVoid = true;
                    break;
                    
                
            }
        }

        public char getGameObjectType()
        {
            if(GameObject == null)
            {
                return '!';
            }
            return GameObject.ObjectType;
            
        }
    }
}