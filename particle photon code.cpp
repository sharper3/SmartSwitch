int relayOnePin = D1; 
int relayTwoPin = D2; 

bool isRelayOneClosed = false;
bool isRelayTwoClosed = false;



void setup() {
    pinMode(relayOnePin, OUTPUT);
    pinMode(relayTwoPin, OUTPUT);
    
    digitalWrite(relayOnePin, HIGH);
    digitalWrite(relayTwoPin, HIGH);
    
    Particle.variable("r1Closed", isRelayOneClosed);
    Particle.variable("r2Closed", isRelayTwoClosed);
    
    Particle.function("toggleR1", toggleRelayOne);
    Particle.function("r1Open", relayOneOpen);
    Particle.function("r1Closed", relayOneClosed);
    
    Particle.function("toggleR2", toggleRelayTwo);
    Particle.function("r2Open", relayTwoOpen);
    Particle.function("r2Closed", relayTwoClosed);
    
}

void loop() {
  
    delay(1000);  
    publishData();
}

int publishData()
{
    String data = String::format("{ \"relayOneClosed\": \"%s\", \"relayTwoClosed\": \"%s\" }", String(isRelayOneClosed).c_str(), String(isRelayTwoClosed).c_str());
    Particle.publish("SmartSwitch", data, PRIVATE);
    
    return 1;
}

int toggleRelayOne(String extra)
{
    if(isRelayOneClosed)
    {
        relayOneOpen("data");
    }
    else
    {
        relayOneClosed("data");
    }
    
    
    return 1;
}

int relayOneOpen(String extra)
{
    isRelayOneClosed = false;
    digitalWrite(relayOnePin, HIGH);
    publishData();
    return 1;
}

int relayOneClosed(String extra)
{
    isRelayOneClosed = true;
    digitalWrite(relayOnePin, LOW);
    publishData();
    return 1;
}

int toggleRelayTwo(String extra)
{
    if(isRelayTwoClosed)
    {
        relayTwoOpen("data");
    }
    else
    {
        relayTwoClosed("data");
    }

    return 1;
}

int relayTwoOpen(String extra)
{
    isRelayTwoClosed = false;
    digitalWrite(relayTwoPin, HIGH);
    publishData();
    return 1;
}

int relayTwoClosed(String extra)
{
    isRelayTwoClosed = true;
    digitalWrite(relayTwoPin, LOW);
    publishData();
    return 1;
}

/*
    {
  "eventName": "SmartSwitch",
  "url": "http://codepalousasmartswitch.azurewebsites.net/api/smartswitch",
  "headers": {
    "Content-Type": "application/json"
  },
  "json": {
    "Id": "{{PARTICLE_DEVICE_ID}}", 
    "RelayOneClosed": "{{relayOneClosed}}",
    "RelayTwoClosed": "{{relayTwoClosed}}"
  }
}

    */