# C-smsAT
send sms using broadband and C#

Add the SMSEngine class to your C# Project

[CODE]
Usage
/*If you want to send a message*/
SmsEngine engine = new SmsEngine(port, interval);
engine.openPort();

if(engine.sendSms(number, message))
{
//Successfully sent!
}
else
{
//Failed
}
engine.closePort();
[/CODE]




