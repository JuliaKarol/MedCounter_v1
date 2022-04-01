using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ObserverPatternMedlab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //nowa instancja "karty" - generowanie nowego wspólnego countera,
            //po zakończeniu liczenia counter clear/opcja triggera w przycisku
            InitializeComponent();
        }
        // Observer Design Pattern
        //
        // Intent: Lets you define a subscription mechanism to notify multiple objects
        // about any events that happen to the object they're observing.
        //
        // Note that there's a lot of different terms with similar meaning associated
        // with this pattern. Just remember that the Subject is also called the
        // Publisher and the Observer is often called the Subscriber and vice versa.
        // Also the verbs "observe", "listen" or "track" usually mean the same thing.

        public interface IObserver
        {
            void Update(ISubject subject);
        }
        //dostuff button observer, main counter observer
        //set limit rtf observer, exception display, rtf click limit display
        //button accesiblility observber
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }
        public interface IDisplay
        {
            //dunno, coś wymyślę
        }
        //public class putting it all together?/Template wzorzec
        public class ButtonSubject : ISubject, IObserver//iobserver tez sie przyda, update z drugiego subjecta
        {
            public int State { get; set; } = -0;//states
            private List<IObserver> _observers = new List<IObserver>();//sub list
            public void Attach(IObserver observer)
            {
                this._observers.Add(observer);
            }
            public void Detach(IObserver observer)
            {
                this._observers.Remove(observer);
            }
            public void Notify()
            {
                //coś robi

                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }

            }
            public void CheckMath()
            {
                ////add to button counter (nowy observer?),
                //add to main counter (nowy observer?),
                //check against ClickLimitCounter number
                ///all counter set state =>  button display
                //math not done set state => button display
                //math done =>button access observer, button display observer, Maincounter Display

                // przykład kodu:
                // this.State = new Random().Next(0, 10);

                //Thread.Sleep(15);

                //Console.WriteLine("Subject: My state has just changed to: " + this.State);
                //this.Notify();
            }
            public void Update(ISubject subject)
            {
                if ((subject as ClickLimitSubject).State < 3)
                {
                    //get ClickLimitCounter number
                }
                //else 
            }
            public class ClickLimitSubject : ISubject
            {
                public int State { get; set; } = -0;//states
                private List<IObserver> _observers = new List<IObserver>();//sub list
                public void Attach(IObserver observer)
                {
                    this._observers.Add(observer);
                }
                public void Detach(IObserver observer)
                {
                    this._observers.Remove(observer);
                }
                public void Notify()
                {
                    //notify button subject with amount

                    foreach (var observer in _observers)
                    {
                        observer.Update(this);
                    }
                }
                public void CheckInputValidity()
                {
                    //trycatch  after clicking set amount
                    //if ok =>ClickLimit display, keep number, wyślij go do button subjecta, get private set
                    //if not ok => exception observer =>exception display 
                }
            }
            public class ButtonDisplay : IObserver//idisplay
            {
                public void Update(ISubject subject)
                {
                    if ((subject as ButtonSubject).State < 3)
                    {
                        //do display stuff
                        //button update
                    }

                }
            }
            public class ButtonAccesibility
            {//ma tez cleara

            }
            public class ClickLimitDisplay
            {

            }
            public class ExceptionObserverDisplay
            {
                //catch exception from click limit, display warning, odpal clear
            }
            public class MainCounterDisplay
            {
                //get number from maint counter, display main counter number
            }

            public class Subject : ISubject
            {
                public int State { get; set; } = -0;//states
                private List<IObserver> _observers = new List<IObserver>();//sub list
                                                                           // The subscription management methods.
                public void Attach(IObserver observer)
                {
                    this._observers.Add(observer);
                }
                public void Detach(IObserver observer)
                {
                    this._observers.Remove(observer);
                }
                public void Notify()
                {
                    //coś robi

                    foreach (var observer in _observers)
                    {
                        observer.Update(this);
                    }
                }
                public void SomeBusinessLogic()
                {
                    Console.WriteLine("\nSubject: I'm doing something important.");
                    this.State = new Random().Next(0, 10);

                    Thread.Sleep(15);

                    Console.WriteLine("Subject: My state has just changed to: " + this.State);
                    this.Notify();
                    //zmiana stanu przy okazji wyliczenia rzeczy/ jeden stan na ok, drugi na nie
                    //logika wyliczania?
                    //notify z przekazaniem stringa
                    //notify tylko klasę/funkcję np./ wyłączającą przyciski
                }
            }

            // Concrete Observers react to the updates issued by the Subject they had
            // been attached to.
            class ConcreteObserverA : IObserver
            {
                public void Update(ISubject subject)
                {
                    if ((subject as Subject).State < 3)
                    {
                        Console.WriteLine("ConcreteObserverA: Reacted to the event.");
                        //button update
                    }
                }
            }

            class ConcreteObserverB : IObserver
            {
                public void Update(ISubject subject)
                {
                    if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
                    {
                        Console.WriteLine("ConcreteObserverB: Reacted to the event.");
                    }
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    // The client code.
                    var subject = new Subject();
                    var observerA = new ConcreteObserverA();
                    subject.Attach(observerA);

                    var observerB = new ConcreteObserverB();
                    subject.Attach(observerB);

                    subject.SomeBusinessLogic();
                    subject.SomeBusinessLogic();

                    subject.Detach(observerB);

                    subject.SomeBusinessLogic();
                }
            }
        }
    }
}
