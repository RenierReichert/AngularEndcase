import { CourseInstance } from "../courses/course-instance";

export interface CourseDBChanges{
    message: string;
    
    changeList: CourseInstance[];
}