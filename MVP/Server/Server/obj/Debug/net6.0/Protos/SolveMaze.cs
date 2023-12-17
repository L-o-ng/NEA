// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SolveMaze.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Server {

  /// <summary>Holder for reflection information generated from Protos/SolveMaze.proto</summary>
  public static partial class SolveMazeReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/SolveMaze.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SolveMazeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZQcm90b3MvU29sdmVNYXplLnByb3RvEgVncmVldCJQCgxTb2x2ZVJlcXVl",
            "c3QSDAoEbWF6ZRgBIAEoCRIRCglhbGdvcml0aG0YAiABKAkSHwoXbWF6ZUdl",
            "bmVyYXRpb25BbGdvcml0aG0YAyABKAkiFAoEUGF0aBIMCgRwYXRoGAEgASgJ",
            "MjsKCk1hemVTb2x2ZXISLQoJU29sdmVNYXplEhMuZ3JlZXQuU29sdmVSZXF1",
            "ZXN0GgsuZ3JlZXQuUGF0aEIJqgIGU2VydmVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.SolveRequest), global::Server.SolveRequest.Parser, new[]{ "Maze", "Algorithm", "MazeGenerationAlgorithm" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.Path), global::Server.Path.Parser, new[]{ "Path_" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SolveRequest : pb::IMessage<SolveRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SolveRequest> _parser = new pb::MessageParser<SolveRequest>(() => new SolveRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SolveRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.SolveMazeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SolveRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SolveRequest(SolveRequest other) : this() {
      maze_ = other.maze_;
      algorithm_ = other.algorithm_;
      mazeGenerationAlgorithm_ = other.mazeGenerationAlgorithm_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SolveRequest Clone() {
      return new SolveRequest(this);
    }

    /// <summary>Field number for the "maze" field.</summary>
    public const int MazeFieldNumber = 1;
    private string maze_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Maze {
      get { return maze_; }
      set {
        maze_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "algorithm" field.</summary>
    public const int AlgorithmFieldNumber = 2;
    private string algorithm_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Algorithm {
      get { return algorithm_; }
      set {
        algorithm_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "mazeGenerationAlgorithm" field.</summary>
    public const int MazeGenerationAlgorithmFieldNumber = 3;
    private string mazeGenerationAlgorithm_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MazeGenerationAlgorithm {
      get { return mazeGenerationAlgorithm_; }
      set {
        mazeGenerationAlgorithm_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SolveRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SolveRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Maze != other.Maze) return false;
      if (Algorithm != other.Algorithm) return false;
      if (MazeGenerationAlgorithm != other.MazeGenerationAlgorithm) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Maze.Length != 0) hash ^= Maze.GetHashCode();
      if (Algorithm.Length != 0) hash ^= Algorithm.GetHashCode();
      if (MazeGenerationAlgorithm.Length != 0) hash ^= MazeGenerationAlgorithm.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Maze.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Maze);
      }
      if (Algorithm.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Algorithm);
      }
      if (MazeGenerationAlgorithm.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MazeGenerationAlgorithm);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Maze.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Maze);
      }
      if (Algorithm.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Algorithm);
      }
      if (MazeGenerationAlgorithm.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MazeGenerationAlgorithm);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Maze.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Maze);
      }
      if (Algorithm.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Algorithm);
      }
      if (MazeGenerationAlgorithm.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MazeGenerationAlgorithm);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SolveRequest other) {
      if (other == null) {
        return;
      }
      if (other.Maze.Length != 0) {
        Maze = other.Maze;
      }
      if (other.Algorithm.Length != 0) {
        Algorithm = other.Algorithm;
      }
      if (other.MazeGenerationAlgorithm.Length != 0) {
        MazeGenerationAlgorithm = other.MazeGenerationAlgorithm;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Maze = input.ReadString();
            break;
          }
          case 18: {
            Algorithm = input.ReadString();
            break;
          }
          case 26: {
            MazeGenerationAlgorithm = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Maze = input.ReadString();
            break;
          }
          case 18: {
            Algorithm = input.ReadString();
            break;
          }
          case 26: {
            MazeGenerationAlgorithm = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class Path : pb::IMessage<Path>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Path> _parser = new pb::MessageParser<Path>(() => new Path());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Path> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.SolveMazeReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path(Path other) : this() {
      path_ = other.path_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path Clone() {
      return new Path(this);
    }

    /// <summary>Field number for the "path" field.</summary>
    public const int Path_FieldNumber = 1;
    private string path_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Path_ {
      get { return path_; }
      set {
        path_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Path);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Path other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Path_ != other.Path_) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Path_.Length != 0) hash ^= Path_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Path_.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Path_);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Path_.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Path_);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Path_.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Path_);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Path other) {
      if (other == null) {
        return;
      }
      if (other.Path_.Length != 0) {
        Path_ = other.Path_;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Path_ = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Path_ = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
