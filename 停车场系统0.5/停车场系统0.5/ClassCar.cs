using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 停车场系统0._5
{
    class ClassCar
    {
        public string name;//车主姓名
        public string number;//车牌号码
        public DateTime time1,time2;
        public int position; //用来记录停到车库里的位置
        public void checkName()
        {
            name = Console.ReadLine();
        }
        public void checkNumber()
        {
            number = Console.ReadLine();
        }
        public void checkTime()
        {
            time1 = DateTime.Now;
        }
        public void checkTime2()
        {
            time2 = DateTime.Now;
        }
    }
}
