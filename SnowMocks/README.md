﻿Zaimplementuj klasę SnowRescueService - to jest Twój SUT. Wszystkie pozostałe klasy potraktuj jako zależności.

1. Wyślij piaskarkę (sander) tylko jeśli temperatura będzie poniżej 0 st. C
2. Wyślij pług (snowplow) tylko jeśli opady śniegu przekroczą 3 mm
  *  jeśli pług nawali (SnowplowMalfunctioningException) - wyślij kolejny
3. Wyślij dwa pługi tylko jeśli opady śniegu przekroczą 5 mm
4. Jeśli temperatura będzie poniżej -10 i opady śniegu przekroczą 10 mm, najpierw wyślij trzy pługi,
 potem piaskarkę a potem powiadom prasę. 	 
		