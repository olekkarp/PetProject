using System;
using OpenQA.Selenium;

namespace PetWithOleksii
{
    public interface IDriverProvider
    {
        IWebDriver GetDriver();
    }
}
