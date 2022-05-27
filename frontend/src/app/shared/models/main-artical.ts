import { article } from "./article";
import { journal } from "./journal";
import { journalName } from "./journal-name";

export interface mainArticle {
  article : article;
  journalName: journalName;
  journal: journal;
}
