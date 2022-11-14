// DATACOUNTER v0.0

uint8_t last_status = 0x0;
uint8_t new_status = 0x0;

void setup() {
  // Serial ON
  Serial.begin(38400);
  // Reading whole port A (pin 22-29 of arduino mega)
  DDRA = 0b00010000; // ALL INPUT but pin 26 (use it for GND)
  PORTA = 0b11101111;
  new_status = PINA;
  last_status = new_status;
  Serial.write(last_status);
}

void loop() {
  new_status = PINA;
  if(new_status != last_status) {
    Serial.write(new_status);
    last_status = new_status;
    delay(10);
  }
}
