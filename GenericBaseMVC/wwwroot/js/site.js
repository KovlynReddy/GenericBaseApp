$(".Theme-Control-option").on('click', function () {
    var val = $(this).val();
    ChangeTheme(val);
    console.log(val);
});

function ChangeTheme(themeName) {
var theme = $("#theme");
var newUrl = `/lib/bootstrap-themes/${themeName}/bootstrap.css`
console.log(newUrl, theme.attr('href'));
theme.attr('href', newUrl);
}

var emojis = {
    emojis : [
        { emoji: ["smile", "face-smile","&#x1F642"]},
        {emoji:["worried", "face-worried", "&#x1F62F" ]},
        {emoji:["sad" ,"face-sad", "&#x1F614" ]},
        {emoji:["sad_sweat", "face-sad-sweat", "&#x1F630" ]},
        {emoji:["laugh", "face-awesome", "&#x1F602" ]},
        {emoji:["lol" ,"face-laugh-squint", "&#x1F606" ]},
        {emoji:["smile_tear", "face-grin-tears","&#x1F605"]},
        {emoji:["rotf" ,"face-grin-squint-tears", "&#x1F923" ]},
        {emoji:["tongue_out", "face-grin-tongue", "&#x1F61B" ]},
        {emoji:["wink", "face-laugh-wink","&#x1F609"]},
        {emoji:["cry" ,"face-sad-cry","&#x1F62D"]},
        {emoji:["blush" ,"face-blush","&#x1F60A"]},
        {emoji:["straight", "face-meh","&#x1F610"]},
        {emoji:["crazy" ,"face-grin-tongue-wink","&#x1F61C"]},
        {emoji:["dead" ,"face-dizzy","&#x1F635"]},
        {emoji:["shocked", "face-flushed","&#x1F628"]},   
        {emoji:["love", "face-grin-hearts","&#x1F60D"]},
        {emoji:["weed" ,"cannabis","&#x1F340"]},
        {emoji:["flame" ,"fire","&#x1F525"]},
        {emoji:["drop" ,"droplet","&#x1F4A7"]},
        {emoji:["hand_peace", "hand-peace","&#x270C"]},
        {emoji:["hand_middle", "hand-middle-finger","&#x1F595"]},
        {emoji:["hand_wave" ,"hand-wave","&#x1F44B"]},
        {emoji:["hand_crossed", "hand-fingers-crossed","&#x1F91E"]},
        {emoji:["hand_fist" ,"hand-fist","&#x1F44A"]},
        {emoji:["hand_shake" ,"handshake","&#x1F91D"]},
        {emoji:["wow" ,"face-surprise","&#x1F632"]},
        {emoji:["kiss" ,"face-kiss-wink-heart","&#x1F618"]},
        {emoji:["cool" ,"face-sunglasses","&#x1F60E"]},
        {emoji:["evil" ,"face-smile-horns","&#x1F608"]},
        {emoji:["serious", "face-angry","&#x1F928"]},
        {emoji:["shock" ,"face-scream","&#x1F631"]},
        {emoji:["sigh" ,"face-sleepy","&#x1F62A"]},
        {emoji:["smirk", "face-smirking","&#x1F60F"]},
        {emoji:["no_emotion", "face-meh-blank","&#x1F636"]},
        {emoji:["no_talk", "face-zipper","&#x1F910"]},
        {emoji:["sick" ,"face-vomit","&#x1F92E"]},
]
};

function GetCodeFromFAClass(className) {
    var matchingCode
    emojis.emojis.forEach((details, index) => {
        var emojiDetails = details;
        faClassName = "fa-" +emojiDetails.emoji[1];
        emojiCode = emojiDetails.emoji[2];
        //console.log(className, faClassName, emojiCode, className == faClassName);
        if (className == faClassName) {
            matchingCode = emojiCode;
            return emojiCode;
        }
    });
    return matchingCode;

}

console.log(emojis);
