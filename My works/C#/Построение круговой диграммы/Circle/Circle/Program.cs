using System;
using System.IO;

namespace Circle
{
    struct Pass
    {
        public int percent;
        public string name;
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Pass[] _pass = new Pass[0];
            string path = @"data.txt";

            StreamReader reading = new StreamReader(path);
            int num_of_pass = Convert.ToInt32(reading.ReadLine());
            int i = 0, num_of_lines = 0;

            _pass = new Pass[num_of_pass];

            while (!reading.EndOfStream)
            {
                if (num_of_lines == 0)
                {
                    _pass[i].percent = Convert.ToInt32(reading.ReadLine());
                    num_of_lines++;
                }
                else if (num_of_lines == 1)
                {
                    _pass[i].name = reading.ReadLine();
                    num_of_lines++;

                    i++;
                    num_of_lines = 0;
                }
            }

            int[] a = new int[num_of_pass];
            int[] b = new int[num_of_pass];
            int[] c = new int[num_of_pass];
            int[] d = new int[num_of_pass];
            d[0] = 25;
            for (int j = 1; j < num_of_pass; j++)
            {
                d[j] = 100 - _pass[j-1].percent + d[j-1];
            }


                Random rand = new Random();
            for (int j = 0; j < num_of_pass; j++)
            {
                a[j] = rand.Next(255);
                b[j] = rand.Next(255);
                c[j] = rand.Next(255);
            }

            string result = "<html lang=\"ru\"> <meta charset=\"utf - 8\"> <style> @import url(https://fonts.googleapis.com/css?family=Montserrat:400); body {font:16px/1.4em\"Montserrat\",Arial,sans-serif;}*{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box;}.chart-text{/*font:16px/1em\"Montserrat\",Arial,sans-serif;*/fill:#000;-moz-transform:translateY(0.25em);-ms-transform:translateY(0.25em);-webkit-transform:translateY(0.25em);transform:translateY(0.25em);} .chart-number{font-size:0.35em;line-height:1;text-anchor:middle;-moz-transform:translateY(-0.25em);-ms-transform:translateY(-0.25em);-webkit-transform:translateY(-0.25em);transform:translateY(-0.25em);}.chart-label{font-size:0.2em;text-transform:uppercase;text-anchor:middle;-moz-transform:translateY(0.7em);-ms-transform:translateY(0.7em);-webkit-transform:translateY(0.7em);transform:translateY(0.7em);}figure{display:flex;justify-content:space-around;flex-direction:column;margin-left:-15px;margin-right:-15px;}@media(min-width:768px){figure{flex-direction:row;}}.figure-content,.figure-key{flex:1;padding-left:15px;padding-right:15px;align-self:center;}.figure-content svg{height:auto;}.figure-key{min-width:calc(8/12);}.figure-key[class*=\"shape-\"]{margin-right:6px;}.figure-key-list { margin: 0; padding: 0; list-style: none; } .figure-key-list li { margin: 0 0 8px; padding: 0; } .shape-circle { display: inline-block; vertical-align: middle; width: 32px; height: 32px; -webkit-border-radius: 50%; -moz-border-radius: 50%; border-radius: 50%; } .sr-only { position: absolute; width: 1px; height: 1px; margin: -1px; padding: 0; overflow: hidden; clip: rect(0,0,0,0); border: 0; }";
            for (int j = 0; j < num_of_pass; j++)
            {
                int k = j + 1;
                result += ".shape-"+ k +"{background-color:RGB("+ a[j]+","+ b[j]+","+ c[j]+");}";
            }
            result += "</style> <body> <figure> <div class=\"figure - content\"> <svg width=\"100 % \" height=\"100 % \" viewBox=\"0 0 42 42\" class=\"donut\" role=\"img\"> <circle class=\"donut - hole\" cx=\"21\" cy=\"21\" r=\"15.91549430918954\" fill=\"#fff\" role=\"presentation\"></circle> <circle class=\"donut-ring\" cx=\"21\" cy=\"21\" r=\"15.91549430918954\" fill=\"transparent\" stroke=\"#d2d3d4\" stroke-width=\"3\" role=\"presentation\"></circle>";
            for (int j = 0; j < num_of_pass; j++)
            {
                int l = 100 - _pass[j].percent;
                result += "<circle class=\"donut - segment\" cx=\"21\" cy=\"21\" r=\"15.91549430918954\" fill=\"transparent\" stroke=\"RGB("+ a[j]+"," +b[j]+"," +c[j]+")\" stroke-width=\"3\" stroke-dasharray=\""+ _pass[j].percent + " " + l + "\" stroke-dashoffset=\""+d[j]+"\"></circle>";
            }
            result += " <<text x=\"21 % \" y=\"22 % \" class=\"chart-number\"> Круговая </text> <text x=\"21 % \" y=\"23 % \" class=\"chart-label\"> Диаграмма </text>/svg> </div> <figcaption class=\"figure-key\"> <ul class=\"figure-key-list\" aria-hidden=\"true\" role=\"presentation\">";
            for (int j = 0; j < num_of_pass; j++)
            {
                int o = j + 1;
                result += "<li> <span class=\"shape-circle shape-"+o+"\"></span>"+ _pass[j].name + "</li>";
            }
            result += "</ul> </figcaption> </figure> </body> </html>";
                string filename = "result.html";
            StreamWriter record = new StreamWriter(filename, false);
            record.WriteLine(result);
            record.Close();
        }
    }
}

