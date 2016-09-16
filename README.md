# C-smsAT
send sms using broadband and C#

Add the SMSEngine class to your C# Project

Usage
/*If you want to send 1 message*/
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





