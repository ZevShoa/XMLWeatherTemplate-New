using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLWeather
{
    class Day
    {
        //declaring all the variables that I need
        public string city, windDirection, windSpeed, currentTemp, highTemp, lowTemp;
        public int conditions;

        public Day(string _city, string _windDirection, string _currentTemp, string _highTemp, string _lowTemp, string _windSpeed, int _conditions)
        {
            city = _city;
            windDirection = _windDirection;
            currentTemp = _currentTemp;
            highTemp = _highTemp;
            lowTemp = _lowTemp;
            windSpeed = _windSpeed;
            conditions = _conditions;
        }
        // getting the values for the weather for either todays weather or the forecast
        public void weatherChooser()
        {
            //chooses information for current day
            #region today
            if (Form1.whatDay == "day1")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("WeatherData.xml");

                //create a node variable to represent the parent element
                XmlNode parent;
                parent = doc.DocumentElement;

                //check each child of the parent element
                foreach (XmlNode child in parent.ChildNodes)
                {
                    // TODO if the "city" element is found display the value of it's "name" attribute
                    if (child.Name == "city")
                    {
                        city = child.Attributes["name"].Value;
                    }
                    if (child.Name == "temperature")
                    {
                        highTemp = child.Attributes["max"].Value;
                        lowTemp = child.Attributes["min"].Value;
                        currentTemp = child.Attributes["value"].Value;
                    }
                    if (child.Name == "wind")
                    {
                        foreach (XmlNode grandChild in child.ChildNodes)
                        {
                            if (grandChild.Name == "speed")
                            {
                                windSpeed = grandChild.Attributes["name"].Value;
                            }
                            if (grandChild.Name == "direction")
                            {
                                windDirection = grandChild.Attributes["name"].Value;
                            }
                        }
                    }
                    if (child.Name == "weather")
                    {
                        conditions = Convert.ToInt32(child.Attributes["number"].Value);
                    }
                }
            }
            #endregion
            // this gets all the information for future days
            #region The next few days
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("WeatherData7Day.xml");

                //create a node variable to represent the parent element
                XmlNode parent;
                parent = doc.DocumentElement;
                int day = 1;
                //check each child of the parent element
                foreach (XmlNode child in parent.ChildNodes)
                {
                    if (child.Name == "forecast")
                    {
                        foreach (XmlNode grandChild in child.ChildNodes)
                        {
                            if (grandChild.Name == "location")
                            {
                                foreach (XmlNode greatgrandchild in grandChild.ChildNodes)
                                {
                                    if (grandChild.Name == "name")
                                    {
                                        city = grandChild.Attributes["name"].Value;
                                    }
                                }
                            }
                                foreach (XmlNode greatGrandChild in grandChild.ChildNodes)
                                {
                                    if (greatGrandChild.Name == "symbol")
                                    {
                                        switch (day)
                                        {
                                            case 1:
                                                day++;
                                                break;
                                            case 2:
                                                if (Form1.whatDay == "day2")
                                                {
                                                    conditions = Convert.ToInt32(greatGrandChild.Attributes["number"].Value);
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 3:
                                                if (Form1.whatDay == "day3")
                                                {
                                                    conditions = Convert.ToInt32(greatGrandChild.Attributes["number"].Value);
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 4:
                                                if (Form1.whatDay == "day4")
                                                {
                                                    conditions = Convert.ToInt32(greatGrandChild.Attributes["number"].Value);
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    if (greatGrandChild.Name == "temperature")
                                    {
                                        switch (day)
                                        {
                                            case 1:
                                                day++;
                                                break;
                                            case 2:
                                                if (Form1.whatDay == "day2")
                                                {
                                                    currentTemp = greatGrandChild.Attributes["day"].Value;
                                                    highTemp = greatGrandChild.Attributes["max"].Value;
                                                    lowTemp = greatGrandChild.Attributes["min"].Value;
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 3:
                                                if (Form1.whatDay == "day3")
                                                {
                                                    currentTemp = greatGrandChild.Attributes["day"].Value;
                                                    highTemp = greatGrandChild.Attributes["max"].Value;
                                                    lowTemp = greatGrandChild.Attributes["min"].Value;
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 4:
                                                if (Form1.whatDay == "day4")
                                                {
                                                    currentTemp = greatGrandChild.Attributes["day"].Value;
                                                    highTemp = greatGrandChild.Attributes["max"].Value;
                                                    lowTemp = greatGrandChild.Attributes["min"].Value;
                                                }
                                                day++;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    if (greatGrandChild.Name == "clouds")
                                    {
                                        switch (day)
                                        {
                                            case 1:
                                                day++;
                                                break;
                                            case 2:
                                                if (Form1.whatDay == "day2")
                                                {
                                                    windSpeed = greatGrandChild.Attributes["all"].Value;
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 3:
                                                if (Form1.whatDay == "day3")
                                                {
                                                    windSpeed = greatGrandChild.Attributes["all"].Value;
                                                }
                                                else
                                                {
                                                    day++;
                                                }
                                                break;
                                            case 4:
                                                if (Form1.whatDay == "day4")
                                                {
                                                    windSpeed = greatGrandChild.Attributes["all"].Value;
                                                }
                                                day++;
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
                #endregion
            }


        }
    
}

