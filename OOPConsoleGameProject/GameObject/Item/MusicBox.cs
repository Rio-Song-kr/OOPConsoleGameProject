namespace OOPConsoleGameProject;

public class MusicBox : Item
{
    private Note[] _playNotes;

    public MusicBox(
        string name,
        string[] descriptions,
        Vector2 position,
        ConsoleColor color = ConsoleColor.Yellow)
        : base(color, '♩', position)
    {
        Name = name;
        Description = new List<string>();

        foreach (string description in descriptions)
        {
            Description.Add(description);
        }

        _playNotes = new Note[]
        {
            new Note(Tone.C, Duration.HALF),
            new Note(Tone.E, Duration.HALF),
            new Note(Tone.G, Duration.HALF),
            new Note(Tone.D, Duration.HALF)
        };
    }

    public override void Use()
    {
        foreach (var note in _playNotes)
        {
            Console.Beep((int)note.ToneValue, (int)note.DurationValue);
        }
    }
}