using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles
{
    public class Carte
    {
        private int _id;
        private string _famille;
        private int _nombre;
        private string _urlImage;

        public Carte(int id = 0, string famille = null, int nombre = 0, string urlImage = null)
        {
            _id = id;
            _famille = famille;
            _nombre = nombre;
            _urlImage = urlImage;
        }

        public int Id { get => _id; set => _id = value; }
        public string Famille { get => _famille; set => _famille = value; }
        public string UrlImage { get => _urlImage; set => _urlImage = value; }
        public int Nombre { get => _nombre; set => _nombre = value; }

        public ObservableCollection<Carte> Melanger(ObservableCollection<Carte> jeu)
        {
            Random rand = new Random();
            int n = jeu.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Carte value = jeu[k];
                jeu[k] = jeu[n];
                jeu[n] = value;
            }
            return jeu;
        }

        public void AddCollection(ObservableCollection<Carte> jeu)
        {
            jeu.Add(new Carte(0, "Pique", 1, "Cartes/as_Pique.png"));
            jeu.Add(new Carte(1, "Pique", 2, "Cartes/deux_Pique.png"));
            jeu.Add(new Carte(2, "Pique", 3, "Cartes/trois_Pique.png"));
            jeu.Add(new Carte(3, "Pique", 4, "Cartes/quatre_Pique.png"));
            jeu.Add(new Carte(4, "Pique", 5, "Cartes/cinq_Pique.png"));
            jeu.Add(new Carte(5, "Pique", 6, "Cartes/six_Pique.png"));
            jeu.Add(new Carte(6, "Pique", 7, "Cartes/sept_Pique.png"));
            jeu.Add(new Carte(7, "Pique", 8, "Cartes/huit_Pique.png"));
            jeu.Add(new Carte(8, "Pique", 9, "Cartes/neuf_Pique.png"));
            jeu.Add(new Carte(9, "Pique", 10, "Cartes/dix_Pique.png"));
            jeu.Add(new Carte(10, "Pique", 11, "Cartes/valet_Pique.png"));
            jeu.Add(new Carte(11, "Pique", 12, "Cartes/dame_Pique.png"));
            jeu.Add(new Carte(12, "Pique", 13, "Cartes/roi_Pique.png"));
            jeu.Add(new Carte(13, "Trefle", 1, "Cartes/as_Trefle.png"));
            jeu.Add(new Carte(14, "Trefle", 2, "Cartes/deux_Trefle.png"));
            jeu.Add(new Carte(15, "Trefle", 3, "Cartes/trois_Trefle.png"));
            jeu.Add(new Carte(16, "Trefle", 4, "Cartes/quatre_Trefle.png"));
            jeu.Add(new Carte(17, "Trefle", 5, "Cartes/cinq_Trefle.png"));
            jeu.Add(new Carte(18, "Trefle", 6, "Cartes/six_Trefle.png"));
            jeu.Add(new Carte(19, "Trefle", 7, "Cartes/sept_Trefle.png"));
            jeu.Add(new Carte(20, "Trefle", 8, "Cartes/huit_Trefle.png"));
            jeu.Add(new Carte(21, "Trefle", 9, "Cartes/neuf_Trefle.png"));
            jeu.Add(new Carte(22, "Trefle", 10, "Cartes/dix_Trefle.png"));
            jeu.Add(new Carte(23, "Trefle", 11, "Cartes/valet_Trefle.png"));
            jeu.Add(new Carte(24, "Trefle", 12, "Cartes/dame_Trefle.png"));
            jeu.Add(new Carte(25, "Trefle", 13, "Cartes/roi_Trefle.png"));
            jeu.Add(new Carte(26, "Carreau", 1, "Cartes/as_Carreau.png"));
            jeu.Add(new Carte(27, "Carreau", 2, "Cartes/deux_Carreau.png"));
            jeu.Add(new Carte(28, "Carreau", 3, "Cartes/trois_Carreau.png"));
            jeu.Add(new Carte(29, "Carreau", 4, "Cartes/quatre_Carreau.png"));
            jeu.Add(new Carte(30, "Carreau", 5, "Cartes/cinq_Carreau.png"));
            jeu.Add(new Carte(31, "Carreau", 6, "Cartes/six_Carreau.png"));
            jeu.Add(new Carte(32, "Carreau", 7, "Cartes/sept_Carreau.png"));
            jeu.Add(new Carte(33, "Carreau", 8, "Cartes/huit_Carreau.png"));
            jeu.Add(new Carte(34, "Carreau", 9, "Cartes/neuf_Carreau.png"));
            jeu.Add(new Carte(35, "Carreau", 10, "Cartes/dix_Carreau.png"));
            jeu.Add(new Carte(36, "Carreau", 11, "Cartes/valet_Carreau.png"));
            jeu.Add(new Carte(37, "Carreau", 12, "Cartes/dame_Carreau.png"));
            jeu.Add(new Carte(38, "Carreau", 13, "Cartes/roi_Carreau.png"));
            jeu.Add(new Carte(39, "Coeur", 1, "Cartes/as_Coeur.png"));
            jeu.Add(new Carte(40, "Coeur", 2, "Cartes/deux_Coeur.png"));
            jeu.Add(new Carte(41, "Coeur", 3, "Cartes/trois_Coeur.png"));
            jeu.Add(new Carte(42, "Coeur", 4, "Cartes/quatre_Coeur.png"));
            jeu.Add(new Carte(43, "Coeur", 5, "Cartes/cinq_Coeur.png"));
            jeu.Add(new Carte(44, "Coeur", 6, "Cartes/six_Coeur.png"));
            jeu.Add(new Carte(45, "Coeur", 7, "Cartes/sept_Coeur.png"));
            jeu.Add(new Carte(46, "Coeur", 8, "Cartes/huit_Coeur.png"));
            jeu.Add(new Carte(47, "Coeur", 9, "Cartes/neuf_Coeur.png"));
            jeu.Add(new Carte(48, "Coeur", 10, "Cartes/dix_Coeur.png"));
            jeu.Add(new Carte(49, "Coeur", 11, "Cartes/valet_Coeur.png"));
            jeu.Add(new Carte(50, "Coeur", 12, "Cartes/dame_Coeur.png"));
            jeu.Add(new Carte(51, "Coeur", 13, "Cartes/roi_Coeur.png"));
        }

        public ObservableCollection<Carte> Sortir(ObservableCollection<Carte> jeu)
        {
            Random rnd = new Random();
            ObservableCollection<Carte> sortie = new ObservableCollection<Carte>();
            int plus = 1;

            for (int i = 0; i < 5; i++)
            {
                int k = rnd.Next(jeu.Count + 1);
                sortie.Add(jeu[k]);
                jeu.RemoveAt(k);
                plus--;
            }
            return sortie;
        }
    }
}
