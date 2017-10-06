using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 停车场系统0._5
{
    class stackCar
    {
        public Stack stop = new Stack();
        public int n=0;   //控制车位
        public int card = 10000; //车辆编号，用来表示一共停留了多少车辆
        public ClassCar car0 = new ClassCar();
        public void into()
        {
            if (n <= 10)
            {

                n++;
                Console.WriteLine("请输入车主姓名：");
                car0.checkName();
                Console.WriteLine("请输入车牌号码：");
                car0.checkNumber();
                Console.WriteLine("登记成功");
                car0.checkTime();
                car0.position = n;
                stop.Push("编号："+card+",车牌:" + car0.number + "姓名："+car0.name+"," + "车辆到达时间为：" + car0.time1); 
                card++;

            }
            else    //车位已满
            {
                Console.WriteLine("停车场已停满车辆，请在便道上等待！待到有车位时再进入");

            }

        }
        
    }
}
