﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 停车场系统0._5
{ 

    interface Iplay
    {
        void show();
    }
    class system
    {

        
        queueRoad stop2 = new queueRoad();
        stackCar0 stop1 = new stackCar0();
        public void show()  //实现接口
        {
            Console.WriteLine("------------------------------------");
            Console.Write("在停车场中停车数：");
            Console.WriteLine(stop1.stop.Count);
            Console.WriteLine("详细列表：");
            
            foreach(var s1 in stop1.stop)
            {
                    Console.WriteLine(s1 + " ");
                    
            }
            Console.WriteLine("------------------------------------");
            Console.Write("在便道上暂停的车有：");
            Console.WriteLine(stop2.road.Count); 
            Console.WriteLine("详细列表:");
            foreach (var s2 in stop2.road)
            {
                Console.WriteLine(s2 + " ");
            }
            Console.WriteLine("-------------------------------------");
            
            /*int p;
            p = Console.Read();
            bool p1 = Convert.ToBoolean(p);
            if(p==5)
            {
                sys();
                Console.Read();
            }*/
            
        }

       
        public void sys()
        {
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|请按照屏幕上的数字进行操作             |");
            Console.WriteLine("|①进站登记                             |");
            Console.WriteLine("|②出站登记                             |");    //出站时引用charge函数
            Console.WriteLine("|③车位状态                             |");   //在车位状态中引用show函数
            Console.WriteLine("|④退出系统                             |");
            Console.WriteLine("|-注意：上述操作仅限数字                |");
            Console.WriteLine("|---------------------------------------|");
            int b = 0;
            b = Convert.ToInt32(Console.ReadLine());
            
            switch (b)
            {
                case (1):
                    {
                        if (stop1.n <= 10)
                        {
                            stop1.into();
                            sys();
                            
                        }
                        else
                        {
                            Console.WriteLine("停车场已停满车辆，请在便道上等待！待到有车位时再进入,现在请您先登记");
                            stop2.wait();
                            sys();
                        }
                     };
                    break;
                case (2):
                    { 
                     if(stop1.n==0)
                     {
                         Console.WriteLine("停车场中没有车辆！");
                         sys();
                     }
                     else
                     {
                         stop1.goOut();
                         sys();
                     }
                    };
                    break;
                case (3):
                    {
                        show();
                        sys();
                     };
                    break;
                case (4):
                    {
                        Environment.Exit(0);//退出系统
                     };
                    break;
                default:
                    {
                        Console.WriteLine("违规操作，请按照规定操作");
                        sys();
                    };
                    break;
            }
        }
    }
}
