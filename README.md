# opp-lap-06
# ปุณณภพ เเสนโสม 683450057-7
# ระบบรับสมัครฝึกอบรม (Training Registration System)

## Class Diagram

```mermaid
classDiagram

%% ──────────────────────────────────────────
%% Interface
%% ──────────────────────────────────────────

class ITrainable {
    <<interface>>
    +ConductTraining(courseName : string) void
    +ApproveResult(participant : Person) void
}

%% ──────────────────────────────────────────
%% Abstract Class
%% ──────────────────────────────────────────

class Person {
    <<abstract>>
    +FirstName : string
    +LastName : string
    +Phone : string
    +Email : string
    +Person(firstName : string, lastName : string, phone : string, email : string)
    +ShowInfo() void*
}

%% ──────────────────────────────────────────
%% Concrete Classes
%% ──────────────────────────────────────────

class Student {
    +StudentId : string
    +Major : string
    +Student(firstName : string, lastName : string, phone : string, email : string, studentId : string, major : string)
    +ShowInfo() void
}

class Instructor {
    +Major : string
    +AcademicRank : string
    +Instructor(firstName : string, lastName : string, phone : string, email : string, major : string, academicRank : string)
    +ShowInfo() void
}

class GeneralPerson {
    +Workplace : string
    +Position : string
    +GeneralPerson(firstName : string, lastName : string, phone : string, email : string, workplace : string, position : string)
    +ShowInfo() void
}

class Trainer {
    +BasePerson : Person
    +Specialty : string
    +Trainer(person : Person, specialty : string)
    +ShowInfo() void
    +ConductTraining(courseName : string) void
    +ApproveResult(participant : Person) void
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
}

%% ──────────────────────────────────────────
%% Relationships
%% ──────────────────────────────────────────

%% Inheritance (สืบทอด)
Person <|-- Student
Person <|-- Instructor
Person <|-- GeneralPerson

%% Trainer implement Interface
ITrainable <|.. Trainer

%% Trainer ใช้ Person (Association)
Trainer o-- Person

%% TrainingSystem จัดการ (Aggregation)
TrainingSystem o-- Person
TrainingSystem o-- Trainer
```

## อธิบาย Relationships

| สัญลักษณ์ | ความหมาย | ใช้ตรงไหน |
|---|---|---|
| `<\|--` | Inheritance (สืบทอด) | Student, Instructor, GeneralPerson สืบทอดจาก Person |
| `<\|..` | Realization (implement interface) | Trainer implement ITrainable |
| `o--` | Aggregation (มีความสัมพันธ์แต่อยู่ได้โดยไม่พึ่งกัน) | Trainer เก็บ Person / TrainingSystem เก็บ List |

## อธิบาย Class แต่ละตัว

### ITrainable (Interface)
- กำหนดว่าวิทยากรต้องทำอะไรได้บ้าง
- `ConductTraining()` → ดำเนินการอบรม
- `ApproveResult()` → อนุมัติผลการอบรม

### Person (Abstract Class)
- class แม่ของทุกคนในระบบ
- เก็บข้อมูลพื้นฐาน ชื่อ นามสกุล เบอร์ Email
- `ShowInfo()` เป็น abstract → class ลูกต้อง override เอง

### Student
- สืบทอดจาก Person
- เพิ่ม `StudentId` และ `Major`

### Instructor
- สืบทอดจาก Person
- เพิ่ม `Major` และ `AcademicRank` (อาจารย์, ผศ., รศ., ศ.)

### GeneralPerson
- สืบทอดจาก Person
- เพิ่ม `Workplace` และ `Position`

### Trainer
- implement ITrainable
- เก็บ `BasePerson` ที่เป็น Instructor หรือ GeneralPerson
- มีความสามารถ `ConductTraining()` และ `ApproveResult()`

### TrainingSystem
- class หลักจัดการทุกอย่าง
- เก็บ `List<Person>` และ `List<Trainer>`
- มี method สำหรับเพิ่มข้อมูลและแสดงผล
