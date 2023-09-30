using CircleHealthGroup.PageObject;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace CircleHealthGroup.StepDefinitions;

[Binding]
public class KneeReplacementAppointmentStepDefinitions
{
    KneeReplacementAppointment kneeReplacementAppointment;

    public KneeReplacementAppointmentStepDefinitions()
    {
        kneeReplacementAppointment = new KneeReplacementAppointment();

    }

    [Given(@"I am a patient wanting to book an appointment")]
    public void GivenIAmAPatientWantingToBookAnAppointment()
    {
        kneeReplacementAppointment.NavigateToWebsite();
        kneeReplacementAppointment.ClickOnCookiesPopup();
        kneeReplacementAppointment.ClickOnBookAppointment();
        
    }

    [When(@"I input my '([^']*)' '([^']*)' and select date")]
    public void WhenIInputMyAndSelectDate(string treatmentType, string location)
    {
        kneeReplacementAppointment.EnterTreatmentType(treatmentType);
        kneeReplacementAppointment.EnterLocation();
        kneeReplacementAppointment.ClickOnSearch();
        kneeReplacementAppointment.ClickOnSelectDate();
    }

    [Then(@"I should see the consultant's availability and location to make my decision")]
    public void ThenIShouldSeeTheConsultantsAvailabilityAndLocationToMakeMyDecision()
    {
        Thread.Sleep(5000);     
        Assert.That(kneeReplacementAppointment.IsConsultantsResultDisplayed);

    }
}

