# opplap 06
# นายปุณณภพ เเสนโสม
# ระบบรับสมัครฝึกอบรม (Training Registration System)
## Class Diagram

```mermaid
classDiagram

%% ─────────────────────────────────────────────
%% Interface (ควรเพิ่ม)
%% ─────────────────────────────────────────────

    class ITrainable {
        <<interface>>
        +ConductTraining(courseName : string) void
        +ApproveResult(participant : Person) void
    }

%% ─────────────────────────────────────────────
%% Abstract Class (ควรแก้ Person ให้เป็น abstract)
%% ─────────────────────────────────────────────

    class Person {
        <<abstract>>
        +FirstName : string
        +LastName : string
        +Phone : string
        +Email : string
        +Person(firstName : string, lastName : string, phone : string, email : string)
        +ShowInfo() void*
    }

%% ─────────────────────────────────────────────
%% Concrete Class
%% ─────────────────────────────────────────────

    class Student {
        +StudentId : string
        +Major : string
        +Student(firstName : string, lastName : string, phone : string, email : string, studentId : string, major : string)
        +ShowInfo() void
    }

    class teacher {
        +Major : string
        +AcademicRank : string
        +teacher(firstName : string, lastName : string, phone : string, email : string, major : string, academicRank : string)
        +ShowInfo() void
    }

    class public_Person {
        +Workplace : string
        +Position : string
        +public_Person(firstName : string, lastName : string, phone : string, email : string, workplace : string, position : string)
        +ShowInfo() void
    }

    class Trainer {
        +BasePerson : Person
        +Specialty : string
        +Trainer(person : Person, specialty : string)
        +ConductTraining(courseName : string) void
        +ApproveResult(participant : Person) void
        +ShowInfo() void
    }

    class TrainingSystem {
        -participants : List~Person~
        -trainers : List~Trainer~
        +AddStudent() void
        +AddInstructor() void
        +AddGeneralPerson() void
        +AddTrainer() void
        +ShowParticipants() void
        +ShowTrainers() void
        +ApproveResult() void
        -ReadSelection(prompt : string, maxInclusive : int) int
    }

    class Program {
        +Main(args : string[]) void$
    }

%% ─────────────────────────────────────────────
%% Relationships
%% ─────────────────────────────────────────────

    %% Inheritance
    Person <|-- Student
    Person <|-- teacher
    Person <|-- public_Person

    %% Realization (Trainer implement ITrainable)
    ITrainable <|.. Trainer

    %% Association (Trainer เก็บ Person ไว้ข้างใน)
    Trainer "1" o-- "1" Person : BasePerson

    %% Aggregation (TrainingSystem เก็บ List)
    TrainingSystem "1" o-- "0..*" Person : participants
    TrainingSystem "1" o-- "0..*" Trainer : trainers

    %% Dependency (Program ใช้ TrainingSystem)
    Program ..> TrainingSystem : uses
```

## อธิบาย Relationships

| สัญลักษณ์ | ชื่อ | ใช้ตรงไหน |
|---|---|---|
| `<\|--` | Inheritance | Student, teacher, public_Person สืบทอด Person |
| `<\|..` | Realization | Trainer implement ITrainable |
| `o--` | Aggregation | TrainingSystem เก็บ List / Trainer เก็บ Person |
| `..>` | Dependency | Program เรียกใช้ TrainingSystem |

## อธิบาย Visibility

| สัญลักษณ์ | ความหมาย |
|---|---|
| `+` | public |
| `-` | private |
| `*` | abstract method |
| `$` | static method |

## อธิบาย Class แต่ละตัว

### ITrainable (Interface)
- กำหนด Contract ของวิทยากร
- `ConductTraining()` ดำเนินการอบรม
- `ApproveResult()` อนุมัติผลการอบรม

### Person (Abstract Class)
- class แม่ของทุกคนในระบบ
- `ShowInfo()` เป็น abstract ให้ class ลูก override

### Student
- สืบทอด Person
- เพิ่ม `StudentId` และ `Major`

### teacher
- สืบทอด Person
- เพิ่ม `Major` และ `AcademicRank`

### public_Person
- สืบทอด Person
- เพิ่ม `Workplace` และ `Position`

### Trainer
- implement `ITrainable`
- เก็บ `BasePerson` ที่เป็น teacher หรือ public_Person
- มี `Specialty` ความเชี่ยวชาญ

### TrainingSystem
- จัดการ List ของ participants และ trainers
- มี method เพิ่มข้อมูล แสดงผล และอนุมัติ

### Program
- `Main()` เป็น static method วนลูปเมนู
