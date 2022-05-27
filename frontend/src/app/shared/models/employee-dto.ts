import { academicDegree, academicDegree2 } from "./academic-degree";
import { academicTitle, academicTitle2 } from "./academic-title";
import { department, department2 } from "./department";
import { Employee } from "./employee";
import { institute } from "./institute";
import { mainArticle } from "./main-artical";
import { position, position2 } from "./position";

export interface EmployeeDto {
  employee: Employee;
  position: position;
  position2: position2;
  academicTitle: academicTitle;
  academicTitle2: academicTitle2;
  academicDegree: academicDegree;
  academicDegree2: academicDegree2;
  department: department;
  department2: department2;
  institute: institute;
  articles: mainArticle[];
}
