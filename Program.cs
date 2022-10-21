using System;
using System.Collections; //이것을 추가해야 Collection을 사용하는게 가능하다

namespace CSharp03
{
    #region 참조타입 ,값타임
    //참조 타입, 힙 메모리 영역에 올라간다. 
    // Array, string
    class ClassBox
    {
        public int number;
        public ClassBox(int number)
        {
            this.number = number;
        }

    }
    //값 타입, 스택 메모리 영역에 올라간다. 
    // int, float ,char
    struct StructBox
    {
        public int number;
        public StructBox(int number)
        {
            this.number = number;
        }
    }
    #endregion 
    class MyList
    {
        object[] array;     //실제 데이터가 있는 메모리를 참조하는 변수
        int capacity;       //배열의 총 길이
        int index;          //인덱스(목차)
        

        //**프로퍼티(변수 형태의 함수)**
        // = 현재는 get만 정의 했기 때문에 값을 가져갈수있다 
        public int Count
        {
            get
            {
                return index;
            }
            
        }

        public MyList()
        {
            index = 0;
            capacity = 4;
            array = new object[capacity];
        }

        //인덱서(indexer)
        //=> 객체의 배열의 index기능을 추가하는 방법.
        public object this[int index]
        {
            get
            {
                return array[index];
            }
        }


        //컬렉션에 값을 추가하는 함수.
        //object자료형 값을 1개 받고  int 자료형의 값을 반환하는 함수.
        public int Add(object value)
        {
            array[index] = value;                           //index번쨰 배열 방에 데이터에 대입한다.
            index++;                                        //index 1증가 시킴

            // 준비된 배열방이 가득 차있다면..
            if (index >= capacity)
            {
                capacity *= 4;                              //용량을 4배 늘린다
                object[] newArray = new object[capacity];   //4배 용량을 가진 배열을 생성함.
                for (int i = 0; i < array.Length; i++)      // 기존 배열의 값을 복사한다.
                    newArray[i] = array[i];                 //newArray i번쨰의 변수에 array투입 

                array = newArray;                           //맴버 변수array를 참조를 newArray로 변경한다.
            }

            return index - 1;                               //몇번쨰의 index에 값이 들어갔는가?
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            if (false)
            {
                #region 값 타입과 참조타입
                //cBox1이 참조하고 있는 주소를 cBox2에 대입했기 때문에 둘의 값이 같다
                ClassBox cBox1 = new ClassBox(10);
                ClassBox cBox2 = cBox1;
                cBox1.number = 5000;

                Console.WriteLine($"cBox1:{cBox1.number}, cBox2:{cBox2.number}");

                //sBox1의 그대로 sBox2가 복사해 가져갔기 때문에 둘의 값은 다르다
                StructBox sBox1 = new StructBox(10);
                StructBox sBox2 = sBox1;
                sBox1.number = 5000;

                Console.WriteLine($"sBox1:{sBox1.number}, sBox2:{sBox2.number}");
                #endregion

                #region 나눗셈
                //형 변환
                float height = 140.5f;
                int num = (int)height; // float값을 int로 형변환한다.(앞에 인트 붙이면됨)
                Console.WriteLine($"num:{num}");

                // int/ float는 float다
                float num2 = 140 / 3f; // int / float = float (반대로도 가능하다)  
                Console.WriteLine($"num2:{num2}");

                //num2 =140/0       //0으로 나눌 수는 없다.(불가능)
                int input = int.Parse(Console.ReadLine());
                num2 = 140 / input;
                Console.WriteLine($"num2{num2}");

                //boxing(박싱)
                object obj = num;   //무슨 자료형이든 포장해서 참조해버리자(무슨 자료형이든 받을수있다) 

                //unboxing(언박싱)
                int num3 = (int)obj;    //아까 int형을 넣었으니까 다시 int형으로 바꾸자.
                #endregion
            }

            int n1 = 10;
            int n2 = 20;
            int n3 = 30;

            //배열: 연속적인 데이터의 집합 
            int[] n = new int[3] { 10, 20, 30 };

            Console.WriteLine(n[0]);
            

            //Collection(컬렉션):갯수가 정해져있는것
            //리스트(List):갯수가 안정해져있는것
            // 배열처럼 여래개의 값을 넣을 수 있지만 그 개수가 정해져있지 않는 자료구죠
            ArrayList list = new ArrayList();   //리스트 객체 생성/
            list.Add(10);
            list.Add("ABC");
            list.Add(30);
            list.Add('C');

            ClassBox box = (ClassBox)list[0];


            Console.WriteLine($"list의 개수는: {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"list[{i}]:{list[i]}");
            }
           
            MyList myList = new MyList();
            myList.Add(100);
            myList.Add(200);
            myList.Add(300);
            myList.Add(400);
            myList.Add(500);

            //myList.Count = 100; set기능. 현재는 set기능이 없다
            Console.WriteLine($"myList의 개수는:{myList.Count}");//get가능         
            for(int i =0; i<myList.Count; i++)
            {
                Console.WriteLine($"myList[{i}]: {myList[i]}");
            }
            
        }
    }
}
