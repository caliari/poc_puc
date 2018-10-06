using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace Uitl
{
    public static class Distance
    {
        public static int GetDistance(string origin, string destination)
        {
            int distance = 0;
            //string from = origin.Text;
            //string to = destination.Text;
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=AIzaSyDu5q8F1iWax4ejACPLsSUXvdaKAYzWVaw";
            string requesturl = url;
            //string requesturl = @"http://maps.googleapis.com/maps/api/directions/json?origin=" + from + "&alternatives=false&units=imperial&destination=" + to + "&sensor=false";
            string content = FileGetContents(requesturl);
            JObject o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
            return distance;
            //ResultingDistance.Text = distance;
        }

        public static string FileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
    }
}
