//Create a WInRAR clone
// WINRAR can compress and decompress ZIP or RAR files

Compressor myCompressor = new ZipCompressor();
myCompressor.Compress(new List<string> { "aaa.png", "bbb.png" });

myCompressor = new RARComppressor(); // if delcare with abtract class , we can change class type 
public abstract class Compressor
{
    public CompressionStrategy CompressionStrategy { get; set; }
    public ExtractionStrategy ExtractionStrategy { get; set; }
    public void Compress(List<string> fileNames)  // instead of in class, be in abstract class help avoid reated code for method
    {
        CompressionStrategy.Compress(fileNames);
    }

    public void Extract(string fileName)
    {
        ExtractionStrategy.Extract(fileName);
    }
}

public class ZipCompressor : Compressor
{
    public string Metadata { get; set; }
    public ZipCompressor()
    {
        CompressionStrategy = new CompressLossless();
        ExtractionStrategy = new ExtractWithoutRecovery();
    }
}

public class RARComppressor : Compressor
{
    public int FileSize;
    public enum BinarySize { }; // 32 bit or 64bit?
    public string EncodingType;
    public RARComppressor()
    {

    }
}

public interface CompressionStrategy
{
    public void Compress(List<string> fileNames);

}
public class CompressLossless : CompressionStrategy
{
    public void Compress(List<string> files)
    {
        files.ForEach(file =>
        {
            Console.WriteLine($"Compression {file}");
        });
    }
}

public interface ExtractionStrategy
{
    public void Extract(string fileMame);
}

public class ExtractWithoutRecovery : ExtractionStrategy
{
    public void Extract(string file)
    {
        Console.Write($"{file} Extracted");
    }
}

public class RARCompressor : Compressor
{
    public int FileSize;
    public enum BinarySize { }; // 32 bit or 64bit?
    public string EncodingType;
    public void Compress()
    {

    }
    public void Extract()
    {

    }
}

public class ZIPCompressor : Compressor
{
    public string Metadata { get; set; }


    public void Compress()
    {

    }
    public void Extract()
    {

    }
}

