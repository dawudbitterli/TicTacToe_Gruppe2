# V320 Projektarbeit TicTacToe
 
 Autoren:
 : David Bitterli
 Abel Solomon

## Produkvision TicTacToe

Die Üblichen "TicTacToe" varianten kennt jeder, wer seine Symbole in eine 3er Reihe gebracht hat, gewinnt die Partie. Für uns ist das zu anspruchslos, keine Partien die in einer Patt Situation enden, deshalb haben wir es und zur Herausforderung gemacht das bekannte Kindheitsspiel zu optimieren. 

Ein "TicTacToe", welches in verschiedenen grössen wie 3x3, 5x5 oder auch 7x7 gespielt werden kann und bei dem es an neuen Strategien bedarf. 

Wir wollen den Kinderspiele-Klassiker nun als digitale und inovative Version an die Spielebegeisterten geben und die Nostalgie zurück bringen.

Das spielen auf einem grösseren Feld wie beispielsweise 7x7 bringt den Vorteil, das der beginnende Spieler nicht den Vorteil hat, durch gezielte Strategien jedes Spiel zu gewinnen. Es bringt auch den Vorteil, dass man weniger häufig in ein Unentschieden gerät. 

Mit unserem Endprodukt wollen wir diese bekannten Probleme aus der Welt schaffen und neues Leben in das Spiel einbringen.

## Produkt Backlog

|Userstories|Beschreibung|Akzeptanzkriterien|
|-----------|------------|------------------|
|**1. Individuelle Spielgrösse**|Als Spieler kann ich eine vorgegebene Spielfeldgrösse auswählen, damit ich meine Individuellen Bedürfnisse befriedigen kann|Der Spieler kann vor dem Beginn des Spiels die grösse wählen und wird korrekt angezeigt|
|**2. Spielzug tätigen**|Als Spieler kann ich wenn ich an der Reihe bin meinen Spielzug tätigen, damit das Spiel fortgesetzt wird|Das Symbol (Kreuze oder Kreise) des Spielers wird auf dem Spielfeld angezeigt|
|**3. Undo Funktion**|Als Spieler kann ich nachdem ich den Spielzug getätigt habe den Spielzug rückgängig machen, damit ich eine Fehleingabe korrigieren kann|Der Spielzug kann ==durch eine Tastenfunktion rücckgängig== gemacht werden|
|**4. Anzeige des Spielenden Spielers**|Als Spieler wird mir angezeigt wer an der Reihe ist, damit ich keinen Spielzug für den Gegner tätige|Nickname des Spielers der an der Reihe ist wird deutlich hervorgehoben|
|**5. Spielende bei Patt**|Als Spieler kann ich ein Patt erspielen, so dass ein Text angezeigt wird und die Partie beendet wird, damit das Spiel nicht unnötig weitergeführt wird|Bei Patt kann kein Spielzug mehr gespielt werden und der text wird automatisch ausgegeben|
|**6. Spielernamen**|Als Spieler kann ich mir vor der Partie einen Spitznamen geben, damit klar erkennbar ist wer ich bin|Die abfrage für die Spitznamen geschieht vor der Auswahl der Brettgrösse und werden korrekt angezeigt|
|**7. Protokoll der Spielzüge**|Als Spieler kann ich alle Spielzüge in einer Textdatei nachsehen, damit ich den Spielverlauf nachvollziehen kann|Spielzüge werden in eine Textdatei eingelesen|
|**8. Farbige Symbole und Namen**|Als Spieler bekomme ich eine zufällige Farbe zugeteilt, damit das Spielfeld schöner aussieht|Die Farben werden zufällig von festgelegten Farben genommen und werden korrekt angezeigt und sind klar unterscheidbar|
|**9. Fehler bei ungültiger Eingabe**|Als Spieler kann ich nur gültige Spielzüge tätigen andernfalls wird mir eine Fehlermeldung ausgegeben, damit der Spieler weiss, dass seine Eingabe ungültig war|Bei ungültiger Eingabe wird automatisch ein Fehlertext ausgegeben|
|**10. Spielesieg**|Als Spieler kann ich die Partie durch 3 oder 4 gleich-aneinanderhängende Symbole gewinnen, damit das Spiel durch einen Sieg beendet werden kann|Wenn bei 3x3 3 Symbole aneinander hängen (vertikal, horizontal oder diagonal) wird das Spiel durch sieg beendet, bei 5x5 und 7x7 mit 4 Symbolen|