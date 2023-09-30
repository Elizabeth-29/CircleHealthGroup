Feature: BookAppointment

As a patient I want to be able to book a knee replacment surgery at a local hospital
close to me by specifying a date

@tag1
Scenario Outline: Patient is able to book an appointment for a treatment
	Given I am a patient wanting to book an appointment
	When I input my '<treatmenttype>' '<location>' and select date
	Then I should see the consultant's availability and location to make my decision

	Examples:
        | treatmenttype            | location      |
        | Knee replacement surgery | Leicester, UK |
        

