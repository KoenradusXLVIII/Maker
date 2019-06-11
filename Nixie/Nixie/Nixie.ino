#define HVPS_PIN D1
#define HVPS_FREQ 15980     
#define HVPS_DC 767         // 75% Duty Cycle

void setup() {
 pinMode(HVPS_PIN, OUTPUT);
 analogWriteFreq(HVPS_FREQ);
 analogWrite(HVPS_DC);
}

void loop() {

}
