# RGBloodsugar
Translate Bloodsugar information from Nightscout into RGB values on your logitech G series hardware

requirements:
for this tool to do anything useful, you...
- must own a Logitech G series device with RGB lighting capabilities.
- must download the Logitech G series SDK from https://www.logitechg.com/en-us/innovation/developer-lab.html (I can't redistribute those files, sorry)
  the zip file contains a LogitechLedEnginesWrapper.dll file, which needs to be in the same folder as the binaries from this project.
- must have installed the Logitech driver package (if you can run the tool that allows you to configure the lights on your Logitech G device, you're set)
- must know the url of a Nightscout website.

usage:
stick these files run the executable and pass the Nightscout url as the command line parameter.
e.g. LogitechLedScout.exe http://www.github.com
It's easiest to set this up by creating a shortcut to the executable and 
the example will fail, since it's not a Nightscout site, but I'm sure you'll get the general idea.

effects:
when your bloodsugar is OK (4-9mmol/l or 72-162) the device leds will be green.
when your bloodsugar is low, the device will turn blue; red for high blood sugars.
when your bloodsugar is rising (fast) or dropping (fast), the device will blink (fast)

e.g. my sugar is 5 but I've just had a snack. 
within five minutes, your leds will quickly blink yellow as your sugar is rising fast, but then the device will turn green, as your sugar is currently still OK.