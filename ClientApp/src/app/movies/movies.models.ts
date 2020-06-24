export interface Movie {
    id: number;
    Title: string;
    Description: string;
    MovieUpKeepGenre: MovieUpKeepGenre;
    DurationInMin: number;
    YearOfRelease: number;
    Director: string;
    DateAdded: Date;
    Rating: number;
    //WasWatched: boolean;
}
export enum MovieUpKeepGenre {
    Action,
    Comedy,
    Horror,
    Thriller
}
