using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 停车场系统0._5
{
    class queueRoad
    {
        public Queue road = new Queue();
        int m;
           public void wait()
            {
                if (m <30)
                {
                    m++;
                    ClassCar car1 = new ClassCar();
                    Console.WriteLine("请输入车主姓名");
                    car1.checkName();
                    Console.WriteLine("请输入车牌号码");
                    car1.checkNumber();

                    car1.checkTime();
                    road.Enqueue("车牌为" + car1.number + "的"+car1.name+"顾客在便道上的第" + m + "位," + "车辆到达时间为：" + car1.time1);

                }
                else
                {
                    Console.WriteLine("便道已满");
                }
            }
    }
}
