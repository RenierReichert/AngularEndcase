import { CourseInstance } from "../courses/course-instance";
import { PlannedCourse } from "./CourseObjs";

export interface CourseDBChanges{
    message: string;
    
    cichangeList: CourseInstance[];

    pcchangeList: PlannedCourse[];
}