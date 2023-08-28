using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTypes
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public string[] Types { get; } =
        {
            "Normal", "Fire", "Water", "Electric", "Grass", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dragon", "Dark", "Steel", "Fairy"
        };
        public Dictionary<double, string> Spaces = new Dictionary<double, string>();

        private string typeEffectiveness = "Select a type to begin!";
        public string TypeEffectiveness
        {
            get { return typeEffectiveness; }
            set { typeEffectiveness = value; NotifyChanged("TypeEffectiveness"); }
        }

        private string type1 = "Normal";

        public string Type1
        {
            get { return type1; }
            set { type1 = value; NotifyChanged("Type1"); CalculateTypeEffectiveness(); }
        }
        private string type2 = "None";

        public string Type2
        {
            get { return type2; }
            set { type2 = value; NotifyChanged("Type2"); CalculateTypeEffectiveness(); }
        }


        public ViewModel() 
        {
            Spaces.Add(0, "");
            Spaces.Add(4, "   ");
            Spaces.Add(2, "    ");
            Spaces.Add(1, "     ");
            Spaces.Add(.5, "      ");
            Spaces.Add(.25, "       ");

            Type1 = "Normal";
            Type2 = "None";

            TypeEffectiveness = CalculateTypeEffectiveness(new string[] {Type1});

        }

        private void CalculateTypeEffectiveness()
        {
            TypeEffectiveness = CalculateTypeEffectiveness(new string[] { Type1, Type2 });
        }
        public string CalculateTypeEffectiveness(string[] types)
        {
            double nor = 1, fir = 1, wat = 1, ele = 1, 
                   gra = 1, ice = 1, fig = 1, poi = 1, 
                   gro = 1, fly = 1, psy = 1, bug = 1, 
                   roc = 1, gho = 1, dra = 1, dar = 1, 
                   ste = 1, fai = 1;
            foreach(string t in types)
            {
                switch (t)
                {
                    case "None":
                        break;
                    case "Normal":
                        fig *= 2;
                        gho *= 0;
                    break;
                    case "Fire":
                        wat *= 2;
                        gro *= 2;
                        roc *= 2;

                        fir /= 2;
                        gra /= 2;
                        ice /= 2; //not in gen 1
                        bug /= 2;
                    break;
                    case "Water":
                        ele *= 2;
                        gra *= 2;

                        fir /= 2;
                        wat /= 2;
                        ice /= 2;
                        ste /= 2; //not in gen 1
                    break;
                    case "Electric":
                        gro *= 2;

                        ele /= 2;
                        fly /= 2;
                    break;
                    case "Grass":
                        fir *= 2;
                        ice *= 2;
                        poi *= 2;
                        fly *= 2;
                        bug *= 2;

                        wat /= 2;
                        ele /= 2;
                        gra /= 2;
                        gro /= 2;
                    break;
                    case "Ice":
                        fir *= 2;
                        fig *= 2;
                        roc *= 2;
                        ste *= 2; //not in gen 1

                        ice /= 2;
                    break;
                    case "Fighting":
                        fly *= 2;
                        psy *= 2;
                        fai *= 2; //not in gen 1

                        bug /= 2;
                        roc /= 2;
                        dar /= 2; //not in gen 1
                    break;
                    case "Poison":
                        gro *= 2;
                        psy *= 2;

                        gra /= 2;
                        fig /= 2;
                        poi /= 2;
                        bug /= 2; //not in gen 1
                        fai /= 2; //not in gen 1
                    break;
                    case "Ground":
                        wat *= 2;
                        gra *= 2;
                        ice *= 2;

                        poi /= 2;
                        roc /= 2;

                        ele *= 0;
                    break;
                    case "Flying":
                        ele *= 2;
                        ice *= 2;
                        roc *= 2;

                        gra /= 2;
                        fig /= 2;
                        bug /= 2;

                        gro *= 0;
                    break;
                    case "Psychic":
                        bug *= 2;
                        gho *= 2; //not in gen 1
                        dar *= 2; //not in gen 1

                        fig /= 2;
                        psy /= 2;
                    break;
                    case "Bug":
                        //gen 1 poison super effective
                        fir *= 2;
                        fly *= 2;
                        roc *= 2;

                        gra /= 2;
                        fig /= 2;
                        gro /= 2;
                    break;
                    case "Rock":
                        wat *= 2;
                        gra *= 2;
                        fig *= 2;
                        gro *= 2;
                        ste *= 2; //not in gen 1

                        nor /= 2;
                        fir /= 2;
                        poi /= 2;
                        fly /= 2;
                    break;
                    case "Ghost":
                        gho *= 2;
                        dar *= 2; //not in gen 1

                        poi /= 2;
                        bug /= 2;

                        nor *= 0;
                        fig *= 0;
                    break;
                    case "Dragon":
                        ice *= 2;
                        dra *= 2;
                        fai *= 2; //not in gen 1 or 2

                        fir /= 2;
                        wat /= 2;
                        ele /= 2;
                        gra /= 2;
                    break;
                    case "Dark": //not in gen 1
                        fig *= 2;
                        bug *= 2;
                        fai *= 2;

                        gho /= 2;
                        dar /= 2;

                        psy *= 0;
                    break;
                    case "Steel": //not in gen 1
                        fir *= 2;
                        fig *= 2;
                        gro *= 2;

                        nor /= 2;
                        gra /= 2;
                        ice /= 2;
                        fly /= 2;
                        psy /= 2;
                        bug /= 2;
                        roc /= 2;
                        dra /= 2;
                        dar /= 2; //not in gen 6
                        ste /= 2;
                        fai /= 2;

                        poi *= 0;
                    break;
                    case "Fairy": //not in gen 1 or 2
                        poi *= 2;
                        ste *= 2;

                        fig /= 2;
                        bug /= 2;
                        dar /= 2;

                        dra *= 0;
                    break;
                }
            }
            return EffectiveList2String(new double[] 
            { 
                nor,fir,wat,ele,gra,ice,fig,poi,gro,fly,psy,bug,roc,gho,dra,dar,ste,fai
            });
        }
        private string EffectiveList2String(double[] list)
        {
            List<string> str = new List<string>();
            for(int i = 0; i < list.Length; i++)
                str.Add( $"{Spaces[list[i]]}{Types[i]}: {list[i]}x");

            str.Sort();
            str.Reverse();
            return String.Join(Environment.NewLine,str.ToArray());
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
