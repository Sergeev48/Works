using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UsersApp
{
    class Picture
    {

            [Key]
            public int id_pic { get; set; }


            public string nazvanie, avtor, kartinka, dat,vremya,nalichie;
            public int god;

        public string Nazvanie
            {
                get { return nazvanie; }
                set { nazvanie = value; }
            }

            public string Avtor
            {
                get { return avtor; }
                set { avtor = value; }
            }
            public int God
            {
                get { return god; }
                set { god = value; }
            }
        public string Kartinka
        {
            get { return kartinka; }
            set { kartinka = value; }
        }
        public string Dat
        {
            get { return dat; }
            set { dat = value; }
        }
        public string Vremya
        {
            get { return vremya; }
            set { vremya = value; }
        }
        public string Nalichie
        {
            get { return nalichie; }
            set { nalichie = value; }
        }

        public Picture() { }
            public Picture(string nazvanie, string avtor, int god, string kartinka, string dat, string vremya, string nalichie)
            {
                this.nazvanie = nazvanie;
                this.avtor = avtor;
                this.god = god;
                this.kartinka = kartinka;
                this.dat = dat;
                this.vremya = vremya;
                this.nalichie = nalichie;

            }
        public Picture(int id_pic, string nazvanie, string avtor, int god, string kartinka, string dat, string vremya, string nalichie)
        {
            this.id_pic = id_pic;
            this.nazvanie = nazvanie;
            this.avtor = avtor;
            this.god = god;
            this.kartinka = kartinka;
            this.dat = dat;
            this.vremya = vremya;
            this.nalichie = nalichie;

        }
        public class ByteImageConverter
        {
            public static ImageSource ByteToImage(byte[] imageData)
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                ImageSource imgSrc = biImg as ImageSource;

                return imgSrc;
            }
        }

    }
    }
