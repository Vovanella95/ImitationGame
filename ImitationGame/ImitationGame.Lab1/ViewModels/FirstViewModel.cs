using ImitationGame.Lab1.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.ThreadUtils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImitationGame.Lab1.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private List<Ellipse> _children;

        public List<Ellipse> Children
        {
            get
            {
                return _children;
            }
            set
            {
                SetProperty(ref _children, value);
            }
        }
        public double DeltaT { get; set; }

        public FirstViewModel()
        {
            Children = new List<Ellipse>
            {
                new Ellipse(10, 100, 100, 0, 80, 4),
                new Ellipse(10, 150, 200, 0, 80, 4),
            };
            DeltaT = 0.001;
            RaiseAllPropertiesChanged();
        }

        private double N
        {
            get
            {
                return Children.Count;
            }
        }

        public MvxCommand MakeNextStepCommand
        {
            get
            {
                return new MvxCommand(MakeStep);
            }
        }
        private async void MakeStep()
        {
            await MakeNextStepAsync();
        }



        public void AddEllipse(Ellipse ellipse)
        {
            Children.Add(ellipse);
        }



        private async Task MakeNextStepAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    var newChildren = new List<Ellipse>();
                    for (int i = 0; i < N; i++)
                    {
                        var x1 = Children[i].X + Children[i].Vx * DeltaT + Axi(i) * (DeltaT * DeltaT) / 2.0;
                        var y1 = Children[i].Y + Children[i].Vy * DeltaT + Ayi(i) * (DeltaT * DeltaT) / 2.0;
                        var vx1 = Children[i].V + Axi(i) * DeltaT;
                        var vy1 = Children[i].V + Ayi(i) * DeltaT;

                        var v1 = Math.Sqrt(vx1 * vx1 + vy1 * vy1);
                        var al1 = Math.Acos(vx1 / v1);
                        newChildren.Add(new Ellipse(Children[i].M, x1, y1, v1, al1, Children[i].Q));
                    }
                    Children = new List<Ellipse>(newChildren);
                    Task.Delay(100).Wait();
                    RaiseAllPropertiesChanged();
                }
            });
        }


        private void MakeNextStep()
        {
            var newChildren = new List<Ellipse>();
            for (int i = 0; i < N; i++)
            {
                var x1 = Children[i].X + Children[i].Vx * DeltaT + Axi(i) * (DeltaT * DeltaT) / 2.0;
                var y1 = Children[i].Y + Children[i].Vy * DeltaT + Ayi(i) * (DeltaT * DeltaT) / 2.0;
                var vx1 = Children[i].V + Axi(i) * DeltaT;
                var vy1 = Children[i].V + Ayi(i) * DeltaT;

                var v1 = Math.Sqrt(vx1 * vx1 + vy1 * vy1);
                var al1 = Math.Acos(vx1 / v1);
                newChildren.Add(new Ellipse(Children[i].M, x1, y1, v1, al1, Children[i].Q));
            }
            Children = new List<Ellipse>(newChildren);
        }


        private double R(int i, int j)
        {
            return Math.Sqrt(Math.Pow(Children[i].X - Children[j].X, 2) + Math.Pow(Children[i].Y - Children[j].Y, 2));
        }
        private double Fij(int i, int j)
        {
            return (Children[i].Q * Children[j].Q) / R(i, j);
        }

        private double Fxi(int i)
        {
            double summ = 0;
            for (int j = 0; j < N; j++)
            {
                if (i != j)
                {
                    summ += Fij(i, j) * Math.Cos(Children[j].Alpha);
                }
            }
            return summ;
        }
        private double Fyi(int i)
        {
            double summ = 0;
            for (int j = 0; j < N; j++)
            {
                if (i != j)
                {
                    summ += Fij(i, j) * Math.Sin(Children[j].Alpha);
                }
            }
            return summ;
        }

        private double Axi(int i)
        {
            return Fxi(i) / Children[i].M;
        }
        private double Ayi(int i)
        {
            return Fyi(i) / Children[i].M;
        }
    }
}
