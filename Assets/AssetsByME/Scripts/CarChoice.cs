using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class CarChoice : MonoBehaviour {

//     public GameObject RedBody;
//     public GameObject BlueBody;
//     public GameObject normalbody;
//     public GameObject police;
//     public int CarImport;
//     void Start () {
//         CarImport = GlobalCar.Instance.CarTyp;
//         if (CarImport == 1)
//         {
//             normalbody.SetActive(false);
//             police.SetActive(false);
//             RedBody.SetActive(true);
//         }
//         if (CarImport == 2)
//         {
//             police.SetActive(false);
//             normalbody.SetActive(false);
//             RedBody.SetActive(false);
//             BlueBody.SetActive(true);
//         }
//         if (CarImport == 3)
//         {
//             normalbody.SetActive(false);
//             RedBody.SetActive(false);
//             BlueBody.SetActive(false);
//             police.SetActive(true);
//         }
//     }
	
// }


    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        
        object Handle(object request);
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            
            return handler;
        }
        
        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    class RedCarHandler : AbstractHandler
    {
        public GameObject RedBody;
        public GameObject BlueBody;
        public GameObject normalbody;
        public GameObject police;
        public override object Handle(object request)
        {
            if ((request.ToString()) == "1")
            {         
                normalbody.SetActive(false);
                police.SetActive(false);
                RedBody.SetActive(true);
                return "";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class BlueCarHandler : AbstractHandler
    {
        public GameObject RedBody;
        public GameObject BlueBody;
        public GameObject normalbody;
        public GameObject police;
        public override object Handle(object request)
        {
            if ((request.ToString()) == "2")
            {
                police.SetActive(false);
                normalbody.SetActive(false);
                RedBody.SetActive(false);
                BlueBody.SetActive(true);
                return "";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class PoliceCarHandler : AbstractHandler
    {
        public GameObject RedBody;
        public GameObject BlueBody;
        public GameObject normalbody;
        public GameObject police;
        public override object Handle(object request)
        {
            if ((request.ToString()) == "3")
            {
                normalbody.SetActive(false);
                RedBody.SetActive(false);
                BlueBody.SetActive(false);
                police.SetActive(true);
                return "";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class CarChoice
    {
        public static int CarImport;
        public static void CarChoiceMethod(AbstractHandler handler)
        {
            CarImport = GlobalCar.Instance.CarTyp;

            handler.Handle(CarImport);
            
        }
    }

    public class Program : MonoBehaviour
    {
        static void Main(string[] args)
        {
            var red = new RedCarHandler();
            var blue = new BlueCarHandler();
            var police = new PoliceCarHandler();
        

            red.SetNext(blue).SetNext(police);

            Client.CarChoiceMethod(red);
        }
    }
